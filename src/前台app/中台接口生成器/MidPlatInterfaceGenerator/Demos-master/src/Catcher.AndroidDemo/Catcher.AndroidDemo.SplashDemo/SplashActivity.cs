using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using System.Threading;
using System.Threading.Tasks;

namespace Catcher.AndroidDemo.SplashDemo
{
    [Activity(Label = "SplashActivity", MainLauncher = true,NoHistory =true ,Theme = "@android:style/Theme.Black.NoTitleBar.Fullscreen")]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            SetContentView(Resource.Layout.splash);
            //version's infomation
            var tvVersion = FindViewById<TextView>(Resource.Id.tv_version);    
            tvVersion.Text ="Version "+ PackageManager.GetPackageInfo(this.PackageName,PackageInfoFlags.MatchAll).VersionName;

            //Method 1��
            //�ù�javaдAndroid��Ӧ�ñȽ���Ϥ
            new Handler().PostDelayed(() =>
            {
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
                this.Finish();
            }, 5000);

            //Method 2:
            //����д��ֻ������5��Ȼ��Ͱ����ҳ������һ�¾���ת����ҳ����
            //Thread.Sleep(5000);
            //this.StartActivity(typeof(MainActivity));
            //this.Finish();

            //Method 3:
            //����д���Ľ��˵ڶ���д���ĳ��ֵ�����
            //Thread thread =  new Thread(() => 
            //{
            //    Thread.Sleep(5000);                
            //    Intent intent = new Intent(this, typeof(MainActivity));
            //    StartActivity(intent);
            //    this.Finish();
            //});            
            //thread.Start();

            //Method 4:
            //��Task��ʵ��
            //Task task = new Task(() =>
            //{
            //    Task.Delay(5000);            
            //});
            //task.ContinueWith(t =>
            //{
            //    StartActivity(new Intent(this, typeof(MainActivity)));
            //    this.Finish();
            //},TaskScheduler.FromCurrentSynchronizationContext());
            //task.Start();


            //Method 5:
            //new Handler().PostDelayed(new Java.Lang.Runnable(() =>
            //{
            //    Intent intent = new Intent(this, typeof(MainActivity));
            //    StartActivity(intent);
            //    this.Finish();
            //}), 5000);

        }
    }
}