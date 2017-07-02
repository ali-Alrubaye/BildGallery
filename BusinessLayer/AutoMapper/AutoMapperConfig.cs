namespace BusinessLayer.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            global::AutoMapper.Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
}
