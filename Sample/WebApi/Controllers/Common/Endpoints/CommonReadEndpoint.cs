namespace Sample.WebApi.Controllers.Common
{
    public class CommonReadEndpoint<TController, TEntity, TItem, TDetail, TFilter> : CommonController,
        IControllerEndpoint<TController, CommonReadEndpointAttribute<TController, TEntity, TItem, TDetail, TFilter>>
        where TController : BaseController
        where TEntity : class, IStrongEntity
        where TItem : class, IDto
        where TDetail : class, IDto
        where TFilter : class, IEntityQueryableDto<TEntity>, IPagingInput
    {
        public IStrongService<TEntity> Service { get; set; }

        [HttpGet]
        [SwaggerOperation("Lấy danh sách [controller]")]
        public async Task<PagingResult<TItem>> GetPage(TFilter input)
        {
            var result = await Service.GetPageByQueryModel<TItem>(input, input.Page, input.Size);
            return PagingResult(result);
        }

        [HttpGet("{id}")]
        [SwaggerOperation("Lấy chi tiết [controller]")]
        public async Task<DataResult<TDetail>> GetDetail(RouteId route)
        {
            var result = await Service.GetFirstById<TDetail>(route.Id);
            return DataResult(result);
        }
    }

    public class CommonReadEndpointAttribute<TController, TEntity, TItem, TDetail, TFilter>
        : BaseControllerEndpointAttribute
        where TController : BaseController
        where TEntity : class, IStrongEntity
        where TItem : class, IDto
        where TDetail : class, IDto
        where TFilter : class, IEntityQueryableDto<TEntity>, IPagingInput
    {
        public override Type EndpointType => typeof(CommonReadEndpoint<TController, TEntity, TItem, TDetail, TFilter>);
    }
}
