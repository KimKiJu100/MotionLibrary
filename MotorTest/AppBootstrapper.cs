using ClassLibrary1.Motions._99.MotionContext;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotorTest
{
    public class AppBootstrapper
    {
        private IServiceProvider _provider;

        public void Run()
        {
            ConfigureServices();
            //var mainForm = _provider.GetRequiredService<MainPresenter>().View;
            var mainForm = _provider.GetRequiredService<Form1>();
            Application.Run(mainForm);
        }

        private void ConfigureServices()
        {
            var services = new ServiceCollection();
            initMVPRegister(services);

            services.AddSingleton<Form1>();
            services.AddSingleton<MotionContext>();

            //services.AddSingleton<IFileListManager, FileListManager>();
            //services.AddSingleton<IDataManager, DataManager>();
            //services.AddSingleton<DatabaseControl>();
            //services.AddSingleton<DataAnalyzer>();
            //services.AddSingleton<IActroLogParser, ActroLogParser>();
            //services.AddSingleton<ISqlExecutor, SqlExecutor>();
            //services.AddSingleton<ISQLCachedManager, SQLCachedManager>();

            //services.AddTransient<IWizardDialogService, WizardDialogService>();
            //services.AddSingleton<IPageService, PageService>();
            //services.AddSingleton<IInstanceIdGenerator, InstanceIdGenerator>();

            ////services.AddSingleton<AppPath>();

            //services.AddSingleton<EventAggreator>();
            //services.AddSingleton<IEventPublisher>(sp => sp.GetRequiredService<EventAggreator>());
            //services.AddSingleton<IEventSubScriber>(sp => sp.GetRequiredService<EventAggreator>());

            _provider = services.BuildServiceProvider();
        }

        /// <summary>
        /// 화면 관련 등록 항목을 정의 합니다.
        /// </summary>
        /// <param name="Container"></param>
        private void initMVPRegister(IServiceCollection Container)
        {
            //Container.AddSingleton<MainForm>();
            //Container.AddSingleton<MainFormModel>();
            //Container.AddSingleton<MainPresenter>();

            //Container.AddSingleton<ucListViewPage>();
            //Container.AddSingleton<ListViewPagePresenter>();
            //Container.AddSingleton<ListViewPageModel>();

            //Container.AddSingleton<SystemLogPagePresenter>();
            //Container.AddSingleton<SystemLogPage>();
            //Container.AddSingleton<SystemLogPageModel>();

            //Container.AddTransient<ConditionPage>();
            //Container.AddTransient<ConditionPagePresenter>();
            //Container.AddTransient<ConditionPageModel>();
            //Container.AddTransient<SpecPagePresenter>();
            //Container.AddTransient<SpecPageModel>();

            //Container.AddTransient<WizardFormBase>();
            //Container.AddTransient<WizardPresenter>();
            //Container.AddTransient<WizardFormModel>();

            //Container.AddTransient<ActionItemPage>();
            //Container.AddTransient<ActionItemPagePresenter>();
            //Container.AddTransient<ActionItemPageModel>();

            //Container.AddSingleton<DetailPagePresenter>();
            //Container.AddSingleton<DetailPage>();
            //Container.AddSingleton<DetailPageModel>();

        }
    }
}
