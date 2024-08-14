namespace HouseRentingSystem.ModelBinders;

using Microsoft.AspNetCore.Mvc.ModelBinding;

public class DecimalModelBinderProvider : IModelBinderProvider
{
    public IModelBinder? GetBinder(ModelBinderProviderContext context) 
        => context.Metadata.ModelType == typeof(decimal) || context.Metadata.ModelType == typeof(decimal?)
            ? new DecimalModelBinder()
            : null;
}