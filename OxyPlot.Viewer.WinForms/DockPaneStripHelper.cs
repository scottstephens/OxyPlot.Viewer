using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WeifenLuo.WinFormsUI.Docking;

namespace OxyPlot.Viewer.WinForms
{
    public class DockPaneStripHelper
    {
        public delegate int HitTestDel(DockPaneStripBase dock_pane_strip, Point client_point);
        public static readonly HitTestDel HitTest;

        private delegate object GetTabsDel(DockPaneStripBase dock_pane_strip);
        private static readonly GetTabsDel GetTabs;

        private static readonly Func<object,int, object> GetTab;

        private static readonly Func<object, IDockContent> GetTabContent;

        static DockPaneStripHelper()
        {
            HitTest = InitializeHitTest();
            GetTabs = InitializeGetTabs();
            GetTab = InitializeGetTab();
            GetTabContent = InitializeGetTabContent();
        }

        public static IDockContent GetContent(DockPaneStripBase dock_pane_strip, Point client_point)
        {
            var tabs = GetTabs(dock_pane_strip);
            var index = HitTest(dock_pane_strip, client_point);
            if (index < 0)
                return null;
            var tab = GetTab(tabs, index);
            var content = GetTabContent(tab);
            return content;
        }

        static HitTestDel InitializeHitTest()
        {
            var type = typeof(DockPaneStripBase);
            var method_info = type.GetMethod("HitTest", BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(Point) }, null);

            return (HitTestDel)Delegate.CreateDelegate(typeof(HitTestDel), method_info);
        }

        static GetTabsDel InitializeGetTabs()
        {
            var type = typeof(DockPaneStripBase);

            var property_info = type.GetProperty("Tabs", BindingFlags.Instance | BindingFlags.NonPublic);

            var getter_info = property_info.GetGetMethod(true);

            return (GetTabsDel)Delegate.CreateDelegate(typeof(GetTabsDel), getter_info);
        }

        static Func<object, int, object> InitializeGetTab()
        {
            var base_name = "WeifenLuo.WinFormsUI.Docking.DockPaneStripBase+TabCollection";
            var assembly_qualified_name = $"{base_name}, {typeof(DockPaneStripBase).Assembly.FullName}";
            var type = Type.GetType(assembly_qualified_name);

            var method_info = type.GetMethod("get_Item", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(int) }, null);

            return MagicMethod1(type, method_info);
        }

        static Func<object,IDockContent> InitializeGetTabContent()
        {
            var base_name = "WeifenLuo.WinFormsUI.Docking.DockPaneStripBase+Tab";
            var assembly_qualified_name = $"{base_name}, {typeof(DockPaneStripBase).Assembly.FullName}";
            var type = Type.GetType(assembly_qualified_name);

            var property_info = type.GetProperty("Content", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            var getter_info = property_info.GetGetMethod(true);

            return MagicMethod2<IDockContent>(type, getter_info);
        }

        // the magic methods here were inspired by 
        // https://codeblog.jonskeet.uk/2008/08/09/making-reflection-fly-and-exploring-delegates/
        static Func<object, int, object> MagicMethod1(Type target_type, MethodInfo method)
        {
            // First fetch the generic form
            MethodInfo genericHelper = typeof(DockPaneStripHelper).GetMethod("MagicMethod1Helper",
                BindingFlags.Static | BindingFlags.NonPublic);

            // Now supply the type arguments
            MethodInfo constructedHelper = genericHelper.MakeGenericMethod
                (target_type, method.GetParameters()[0].ParameterType, method.ReturnType);

            // Now call it. The null argument is because it's a static method.
            object ret = constructedHelper.Invoke(null, new object[] { method });

            // Cast the result to the right kind of delegate and return it
            return (Func<object, int, object>)ret;
        }

        static Func<object, TParam, object> MagicMethod1Helper<TTarget, TParam, TReturn>(MethodInfo method)
        where TTarget : class
        {
            // Convert the slow MethodInfo into a fast, strongly typed, open delegate
            Func<TTarget, TParam, TReturn> func = (Func<TTarget, TParam, TReturn>)Delegate.CreateDelegate
                (typeof(Func<TTarget, TParam, TReturn>), method);

            // Now create a more weakly typed delegate which will call the strongly typed one
            Func<object, TParam, object> ret = (object target, TParam param) => func((TTarget)target, param);
            return ret;
        }

        static Func<object, TReturn> MagicMethod2<TReturn>(Type target_type, MethodInfo method)
        {
            // First fetch the generic form
            MethodInfo genericHelper = typeof(DockPaneStripHelper).GetMethod("MagicMethod2Helper",
                BindingFlags.Static | BindingFlags.NonPublic);

            // Now supply the type arguments
            MethodInfo constructedHelper = genericHelper.MakeGenericMethod
                (target_type, method.ReturnType);

            // Now call it. The null argument is because it's a static method.
            object ret = constructedHelper.Invoke(null, new object[] { method });

            // Cast the result to the right kind of delegate and return it
            return (Func<object, TReturn>)ret;
        }

        static Func<object, TReturn> MagicMethod2Helper<TTarget, TReturn>(MethodInfo method)
        where TTarget : class
        {
            // Convert the slow MethodInfo into a fast, strongly typed, open delegate
            Func<TTarget, TReturn> func = (Func<TTarget, TReturn>)Delegate.CreateDelegate
                (typeof(Func<TTarget, TReturn>), method);

            // Now create a more weakly typed delegate which will call the strongly typed one
            Func<object, TReturn> ret = (object target) => func((TTarget)target);
            return ret;
        }

        
            
    }
}
