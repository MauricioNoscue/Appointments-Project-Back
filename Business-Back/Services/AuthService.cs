﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Back.Implements.ModelDataImplement.Security;
using Data_Back.Interface;
using Data_Back.Interface.IDataModels.Security;
using Data_Back.Interface.Refresh;
using Entity_Back.Dto.Auth;
using Entity_Back.Models.SecurityModels;
using Microsoft.Extensions.Logging;
using Utilities_Back.Exceptions;

namespace Business_Back.Services
{
    public class AuthService
    {
        private readonly IUserData _userData;                 
        private readonly IRefreshTokenData _refreshTokenData;   
        private readonly JWTService _jwtService;               
        private readonly ILogger<AuthService> _logger;
        private readonly IRolUserData _roluser;
        private readonly IDoctorData _dctorData;

        // TTL configurables
        private readonly TimeSpan _accessTtl = TimeSpan.FromMinutes(60);
        private readonly TimeSpan _refreshTtl = TimeSpan.FromDays(7);

        public AuthService(
            IUserData userData,
            IRefreshTokenData refreshTokenData,
            JWTService jwtService,
            ILogger<AuthService> logger, IRolUserData roluser, IDoctorData dctorData)
        {
            _userData = userData;
            _refreshTokenData = refreshTokenData;
            _jwtService = jwtService;
            _logger = logger;
            _roluser = roluser;
            _dctorData = dctorData;
        }

        // ============================================
        // Login clásico que ya tienes (se deja igual)
        // ============================================
        public async Task<User?> Login(string email, string password)
        {
            // Comentario: tu Data ya valida BCrypt internamente
            var user = await _userData.validarCredenciales(email, password);
            if (user == null) return null;
            return user;
        }

        // ==========================================================
        // NUEVO: Login + emisión de tokens (access + refresh)
        // - Usa tu validarCredenciales existente
        // - Devuelve tokens para el frontend
        // ==========================================================
        public async Task<AuthResultDto?> LoginWithTokensAsync(string email, string password, string? ip = null)
        {
            try
            {
                var user = await _userData.validarCredenciales(email, password);
                if (user == null) return null;

                var roles = await _roluser.GetAllByUserIdAsync(user.Id);

                var doctor = await _dctorData.GetDoctorByUserIdAsync(user.Id);

                // Generar access token (JWT)
                var accessToken = _jwtService.GenerateToken(user.Id.ToString(), user.Email, roles,doctor);
                var accessExp = DateTime.UtcNow.Add(_accessTtl);

                // Crear refresh en Data
                var refresh = await _refreshTokenData.CreateAsync(user.Id, _refreshTtl, ip);

                return new AuthResultDto
                {
                    AccessToken = accessToken,
                    RefreshToken = refresh.Token,
                    ExpiresAtUtc = accessExp
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en LoginWithTokensAsync para {Email}", email);
                throw new BusinessException("Authentication failed.", ex);
            }
        }

        // ==========================================================
        // NUEVO: Refresh → valida/rota refresh y emite nuevos tokens
        // ==========================================================
        public async Task<AuthResultDto?> RefreshAsync(string refreshToken, string? ip = null)
        {
            try
            {
                // Buscar refresh activo (Data valida expiración y revocación)
                var tokenEntity = await _refreshTokenData.GetActiveByTokenAsync(refreshToken);
                if (tokenEntity == null) return null;

                var user = tokenEntity.User;

                // Rotar refresh: revocar actual y crear uno nuevo
                tokenEntity.RevokedAtUtc = DateTime.UtcNow;
                tokenEntity.ReplacedByToken = null; // se completa luego

                var newRefresh = await _refreshTokenData.CreateAsync(user.Id, _refreshTtl, ip);
                tokenEntity.ReplacedByToken = newRefresh.Token;

                await _refreshTokenData.SaveChangesAsync();


                var roles = await _roluser.GetAllByUserIdAsync(user.Id);
                var doctor = await _dctorData.GetDoctorByUserIdAsync(user.Id);

                // Emitir nuevo access
                var newAccess = _jwtService.GenerateToken(user.Id.ToString(), user.Email, roles, doctor);
                var accessExp = DateTime.UtcNow.Add(_accessTtl);

                return new AuthResultDto
                {
                    AccessToken = newAccess,
                    RefreshToken = newRefresh.Token,
                    ExpiresAtUtc = accessExp
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en RefreshAsync");
                throw new BusinessException("Refresh failed.", ex);
            }
        }
    }

}
