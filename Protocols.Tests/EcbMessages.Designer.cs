﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Protocols.Tests {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class EcbMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal EcbMessages() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Protocols.Tests.EcbMessages", typeof(EcbMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на &lt;?xml version=&quot;1.0&quot; encoding=&quot;UTF-8&quot;?&gt;
        ///&lt;gesmes:Envelope xmlns:gesmes=&quot;http://www.gesmes.org/xml/2002-08-01&quot; xmlns=&quot;http://www.ecb.int/vocabulary/2002-08-01/eurofxref&quot;&gt;
        ///	&lt;gesmes:subject&gt;Reference rates&lt;/gesmes:subject&gt;
        ///	&lt;gesmes:Sender&gt;
        ///		&lt;gesmes:name&gt;European Central Bank&lt;/gesmes:name&gt;
        ///	&lt;/gesmes:Sender&gt;
        ///	&lt;Cube&gt;
        ///		&lt;Cube time=&apos;2021-03-19&apos;&gt;
        ///			&lt;Cube currency=&apos;USD&apos; rate=&apos;1.1891&apos;/&gt;
        ///			&lt;Cube currency=&apos;JPY&apos; rate=&apos;129.54&apos;/&gt;
        ///			&lt;Cube currency=&apos;BGN&apos; rate=&apos;1.9558&apos;/&gt;
        ///			&lt;Cube currency=&apos;CZK&apos; rate=&apos;26.127&apos;/&gt;
        ///	 [остаток строки не уместился]&quot;;.
        /// </summary>
        internal static string RateResponse {
            get {
                return ResourceManager.GetString("RateResponse", resourceCulture);
            }
        }
    }
}