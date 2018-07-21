using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using CharadesLibrary.Generator;

namespace AndroidCourse
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private readonly WordGenerator _wordGenerator;

        public MainActivity()
        {
            _wordGenerator = new WordGenerator();;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            var charadeButton = FindViewById<Button>(Resource.Id.GenerateCharade);
            var wordDisplay = FindViewById<TextView>(Resource.Id.WordDisplay);

            charadeButton.Click += async delegate
            {
                wordDisplay.Text = "Running generator";
                var randomWord = await _wordGenerator.GetRandomWikiPage();

                wordDisplay.Text = randomWord;
            };
        }
    }
}

