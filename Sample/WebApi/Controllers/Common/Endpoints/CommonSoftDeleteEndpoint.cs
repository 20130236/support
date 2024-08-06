namespace Sample.WebApi.Controllers.Common
{
    public class CommonSoftDeleteEndpoint<TController, TEntity> : CommonController,
        IControllerEndpoint<TController, CommonSoftDeleteEndpointAttribute<TController, TEntity>>
        where TController : BaseController
        where TEntity : class, IStrongEntity
    {
        public IStrongService<TEntity> Service { get; set; }

        [HttpDelete("{id}")]
        [SwaggerOperation("Khóa [controller]")]
        [Transactional]
        public async Task<SuccessResult> SoftDelete(RouteId route)
        {
            await Service.SoftDelete(route.Id);
            return SuccessResult();
        }

        [HttpPut("{id}/Restore")]
        [SwaggerOperation("Mở khóa [controller]")]
        [Transactional]
        public async Task<SuccessResult> Restore(RouteId route)
        {
            await Service.Restore(route.Id);
            return SuccessResult();
        }
    }

    public class CommonSoftDeleteEndpointAttribute<TController, TEntity>
        : BaseControllerEndpointAttribute
        where TController : BaseController
        where TEntity : class, IStrongEntity
    {
        public override Type EndpointType => typeof(CommonSoftDeleteEndpoint<TController, TEntity>);
    }
}
