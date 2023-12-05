#if ANDROID
using Android.Graphics.Drawables;
#endif
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace PickerIssueNet8;

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
			});

        PickerHandler.Mapper.AppendToMapping("PickerBorder", (handler, picker) =>
        {
#if ANDROID
            var shape = new GradientDrawable();

            shape.SetShape(ShapeType.Rectangle);

            if (((Picker)picker).BackgroundColor != null)
                shape.SetColor(((Picker)picker).BackgroundColor.ToPlatform());

            shape.SetStroke(2, Colors.LightGray.ToPlatform());

            shape.SetCornerRadius(16);

            handler.PlatformView.SetBackground(shape);

#endif
        });


#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

