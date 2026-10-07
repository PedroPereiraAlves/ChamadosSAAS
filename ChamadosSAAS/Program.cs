using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAntiforgery(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.SameSite = SameSiteMode.Strict;
    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
});

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());

    var messages = options.ModelBindingMessageProvider;
    messages.SetAttemptedValueIsInvalidAccessor((value, name) => $"O valor \"{value}\" não é válido para {name}.");
    messages.SetNonPropertyAttemptedValueIsInvalidAccessor(value => $"O valor \"{value}\" não é válido.");
    messages.SetMissingBindRequiredValueAccessor(name => $"Informe um valor para {name}.");
    messages.SetMissingKeyOrValueAccessor(() => "Informe um valor.");
    messages.SetMissingRequestBodyRequiredValueAccessor(() => "O corpo da requisição é obrigatório.");
    messages.SetNonPropertyUnknownValueIsInvalidAccessor(() => "O valor informado não é válido.");
    messages.SetNonPropertyValueMustBeANumberAccessor(() => "O valor deve ser numérico.");
    messages.SetUnknownValueIsInvalidAccessor(name => $"O valor informado para {name} não é válido.");
    messages.SetValueIsInvalidAccessor(value => $"O valor \"{value}\" não é válido.");
    messages.SetValueMustBeANumberAccessor(name => $"O campo {name} aceita apenas números.");
    messages.SetValueMustNotBeNullAccessor(name => $"Informe um valor para {name}.");
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/Home/Error");

app.Use(async (context, next) =>
{
    var headers = context.Response.Headers;
    headers["X-Content-Type-Options"] = "nosniff";
    headers["X-Frame-Options"] = "DENY";
    headers["Referrer-Policy"] = "strict-origin-when-cross-origin";
    headers["Permissions-Policy"] = "camera=(), microphone=(), geolocation=()";
    await next();
});

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}")
    .WithStaticAssets();

app.Run();
