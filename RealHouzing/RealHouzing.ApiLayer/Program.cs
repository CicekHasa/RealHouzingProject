using RealHouzing.BusinessLayer.Abstract;
using RealHouzing.BusinessLayer.Concrete;
using RealHouzing.DataAccessLayer.Abstract;
using RealHouzing.DataAccessLayer.Concrete;
using RealHouzing.DataAccessLayer.Entity_Framework;
using RealHouzing.EntityLayer.Concrete;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>();//Db eriþimi için!
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddScoped<IProductDal, EfProductDal>();
builder.Services.AddScoped<IProductService, ProductManager>();

builder.Services.AddScoped<IServiceCategoiresDal, EfServiceCategoriesDal>();
builder.Services.AddScoped<IServiceCategoriesService,ServiceCategoriesManager>();

builder.Services.AddScoped<IMainContentDal, EfMainContentDal>();
builder.Services.AddScoped<IMainContentService, MainContentManager>();

builder.Services.AddScoped<IFeatureCardDal,EfFeatureCardDal>();
builder.Services.AddScoped<IFeatureCardService, FeatureCardManager>();

builder.Services.AddScoped<IReviewDal,EfReviewDal>();
builder.Services.AddScoped<IReviewService,ReviewManger>();

builder.Services.AddScoped<INewDal,EfNewDal>();
builder.Services.AddScoped<INewService,NewManager>();

builder.Services.AddScoped<ISubscribeDal,EfSubscribeDal>();
builder.Services.AddScoped<ISubscribeService,SubscribeManager>();

builder.Services.AddScoped<IAboutDal,EfAboutDal>();
builder.Services.AddScoped<IAboutService,AboutManager>();

builder.Services.AddScoped<ICompanyValueDal,EfCompanyValueDal>();
builder.Services.AddScoped<ICompanyValueService, CompanyValueManager>();

builder.Services.AddScoped<IFrequentlyAskedQuestionDal, EfFrequentlyAskedQuestionDal>();
builder.Services.AddScoped<IFrequentlyAskedQuestionService, FrequentlyAskedQuestionManager>();

builder.Services.AddScoped<ITeamMemberDal,EfTeamMemberDal>();
builder.Services.AddScoped<ITeamMemberService,TeamMemberManager>();

builder.Services.AddScoped<IServiceDal,EfServiceDal>();
builder.Services.AddScoped<IServicesService, ServiceManager>();

builder.Services.AddScoped<IPlanDal,EfPlanDal>();
builder.Services.AddScoped<IPlanService,PlanManager>();

builder.Services.AddScoped<IContactInfoDal,EfContactInfoDal>();
builder.Services.AddScoped<IContactInfoService,ContactInfoManager>();

builder.Services.AddScoped<IContactMessageDal,EfContactMessageDal>();
builder.Services.AddScoped<IContactMessageService,ContactMessageManager>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
