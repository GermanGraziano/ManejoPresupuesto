﻿using System.Security.Claims;

namespace ManejoPresupuesto.Servicios
{
    public class ServicioUsuarios:IServiciosUsuarios
    {

        private readonly HttpContext _httpContext;
        public ServicioUsuarios(IHttpContextAccessor httpContextAccesor)
        {

            _httpContext = httpContextAccesor.HttpContext; 

        }
        public int ObtenerUsuarioId()
        {
            if (_httpContext.User.Identity.IsAuthenticated)
            {
                var idClaim = _httpContext.User
                    .Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();
                var id = int.Parse(idClaim.Value);
                return id;
            
            }
            else
            {
                throw new ApplicationException("El usuario no esta auteticado");
            }


        }
    }
}
