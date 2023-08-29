using Microsoft.Extensions.Logging;

namespace accounting;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                //fonts.AddFont("Font Awesome 6 Brands-Regular-400.otf", "FA-B");
                //fonts.AddFont("Font Awesome 6 Free-Regular-400.otf", "FA-R");
                fonts.AddFont("Font Awesome 6 Free-Solid-900.otf", "FA-S");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

