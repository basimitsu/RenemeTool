using System;
using System.Reflection;
using System.Windows;
using System.Windows.Interactivity;

namespace Utility.Event
{
    public class BSCallMethodAction : TriggerAction<DependencyObject>
    {
        /// <summary>
        /// イベント発生時に呼び出すメソッドを定義できるように登録
        /// </summary>
        public static readonly DependencyProperty MethodNameProperty =
            DependencyProperty.Register("MethodName", typeof(string), typeof(BSCallMethodAction), new UIPropertyMetadata());

        /// <summary>
        /// 呼び出すメソッドのパラメータを指定、または取得できるように登録
        /// </summary>
        public static readonly DependencyProperty MethodParameterProperty =
            DependencyProperty.Register("MethodParameter", typeof(object), typeof(BSCallMethodAction), new UIPropertyMetadata(null));

        /// <summary>
        /// メソッドを呼び出すオブジェクトを指定、または取得できるように登録
        /// </summary>
        public static readonly DependencyProperty MethodTargetProperty =
            DependencyProperty.Register("MethodTarget", typeof(object), typeof(BSCallMethodAction), new UIPropertyMetadata(null));

        /// <summary>
        /// イベント発生時に呼び出すメソッド名を指定、または取得します。
        /// </summary>
        public string MethodName
        {
            get { return (string)GetValue(MethodNameProperty); }
            set { SetValue(MethodNameProperty, value); }
        }

        /// <summary>
        /// 呼び出すメソッドのパラメータを指定、または取得します。
        /// </summary>
        public object MethodParameter
        {
            get { return (object)GetValue(MethodParameterProperty); }
            set { SetValue(MethodParameterProperty, value); }
        }

        /// <summary>
        /// メソッドを呼び出すオブジェクトを指定、または取得します。
        /// <para>ほとんどの場合は対応するViewModel（{Binding}）。</para>
        /// </summary>
        public object MethodTarget
        {
            get { return (object)GetValue(MethodTargetProperty); }
            set { SetValue(MethodTargetProperty, value); }
        }

        /// <summary>
        /// イベント発生時に、指定されたメソッドを呼び出します。
        /// </summary>
        /// <param name="parameter"></param>
        protected override void Invoke(object parameter)
        {
            // 呼び出し対象のメソッドが所属しているクラスを取得
            var vm = this.MethodTarget ?? _getDataContext();

            if (vm == null)
            {
                return;
            }

            if (this.MethodParameter == null)
            {
                // パラメータ無しの場合
                MethodInfo method = vm.GetType().GetMethod(this.MethodName, Type.EmptyTypes);

                if (method == null)
                {
                    return;
                }

                method.Invoke(vm, null);
            }
            else
            {
                // パラメータありの場合
                MethodInfo method = vm.GetType().GetMethod(this.MethodName, new Type[] { this.MethodParameter.GetType() });

                if (method == null)
                {
                    return;
                }

                method.Invoke(vm, new object[] { this.MethodParameter });
            }
        }

        /// <summary>
        /// <see cref="Utility.Event.BSCallMethodAction.MethodParameter"/>のウィンドウに紐づいた、データコンテキストを取得します。
        /// </summary>
        /// <returns></returns>
        private object _getDataContext()
        {
            if (this.MethodParameter == null)
            {
                return null;
            }

            return Window.GetWindow((DependencyObject)this.MethodParameter).DataContext;
        }
    }
}
