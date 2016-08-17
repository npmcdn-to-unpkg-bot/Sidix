using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Dixus.WebUI.HtmlHelpers
{
    public static class UIHelpers
    {
        public static MvcHtmlString indicadorDeSuelo(this HtmlHelper helper, string color)
        {
            TagBuilder tag = new TagBuilder("div");
            tag.AddCssClass("cuadro-indicador-suelo");
            tag.MergeAttribute("style", "background-color:" + color + ";");
            return MvcHtmlString.Create(tag.ToString());
        }

        public static MvcHtmlString bootstrapCheckboxFor<TModel>(this HtmlHelper<TModel> helper, Expression<Func<TModel, bool>> expression, object formGroupAttributes, object checkboxAttributes, string label)
        {
            //prueba
            var expressionText = ExpressionHelper.GetExpressionText(expression);
            var fieldid = helper.ViewData.TemplateInfo.GetFullHtmlFieldId(expressionText);
            var fieldname = helper.ViewData.TemplateInfo.GetFullHtmlFieldName(expressionText);

            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            var displayName = metadata.DisplayName ?? null;
            string propertyName = metadata.PropertyName;
            string[] errors = new string[] { };
            string labelText = displayName ?? label ?? propertyName ?? "hola";
            if(helper.ViewData.ModelState[propertyName] != null)
                errors = helper.ViewData.ModelState[propertyName].Errors.Select(x => x.ErrorMessage).ToArray();

            TagBuilder Validationmessage = new TagBuilder("span");
            Validationmessage.AddCssClass("field-validation-error");
            Validationmessage.AddCssClass("text-danger");
            Validationmessage.MergeAttribute("data-valmsg-for", propertyName);
            Validationmessage.MergeAttribute("data-valmsg-replace", "true");
            Validationmessage.InnerHtml = string.Join(",",errors);

            TagBuilder Checkbox = new TagBuilder("input");
            Checkbox.MergeAttribute("id", propertyName);
            Checkbox.MergeAttribute("name", propertyName);
            Checkbox.MergeAttribute("value", "true");
            Checkbox.MergeAttribute("type", "checkbox");
            Checkbox.MergeAttribute("data-bind", "checked: estaVendida");
            Checkbox.MergeAttributes(GetPropertyValidationAttributes(helper, expression, null));
            if (GetPropertyValueFromLambdaExpression(helper, expression) == "True") Checkbox.Attributes.Add("checked", "checked");

            TagBuilder tbhidden = new TagBuilder("input");
            tbhidden.Attributes.Add("type", "hidden");
            tbhidden.Attributes.Add("value", "false");
            tbhidden.Attributes.Add("name",propertyName);

            TagBuilder Label = new TagBuilder("label");
            Label.InnerHtml = Checkbox.ToString() + labelText + Validationmessage.ToString();

            TagBuilder Divcheckbox = new TagBuilder("div");
            Divcheckbox.AddCssClass("checkbox");
            Divcheckbox.InnerHtml = Label.ToString();

            TagBuilder Formgroup = new TagBuilder("div");
            Formgroup.AddCssClass("form-group");
            Formgroup.InnerHtml = Divcheckbox.ToString();

            return MvcHtmlString.Create(Formgroup.ToString());
        }

        public static string tableClasses(this HtmlHelper helper, string alignment)
        {
            string align = "";
            if (alignment == "left") { align = align + "text-left"; }
            if (alignment == "center") { align = align + "text-center"; }
            if (alignment == "right") { align = align + "text-right"; }
            return align + " mdl-data-table mdl-js-data-table data-table tabla-extendida";
        }

        /// <summary>
        /// Regresa un titulo 'h3' con clase 'page-title' con su respectiva linea verde divisora y un margen hacia abajo
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="title">El titulo que irá en el texto del elemento</param>
        /// <returns></returns>
        public static MvcHtmlString PageTitle(this HtmlHelper helper, string title)
        {
            return UIHelpers.PageTitle(helper, title, null, true, true);
        }
        /// <summary>
        /// Regresa un titulo 'h3' con clase 'page-title' acompañado de un texto pequeño a su derecha y con su respectiva linea verde divisora y un margen hacia abajo
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="title">El titulo que irá en el texto del elemento</param>
        /// <param name="smallText">El texto secundario y más pequeño que será insertado a la derecha de el título</param>
        /// <returns></returns>
        public static MvcHtmlString PageTitle(this HtmlHelper helper, string title, string smallText)
        {
            return UIHelpers.PageTitle(helper, title, smallText, true, true);
        }
        public static MvcHtmlString PageTitle(this HtmlHelper helper, string title, bool includeGreenStripe, bool includeBottomMargin)
        {
            return UIHelpers.PageTitle(helper, title, null, includeGreenStripe, includeBottomMargin);
        }
        /// <summary>
        /// Regresa un titulo 'h3' con clase 'page-title' acompañado de un texto pequeño a su derecha. Opcionalmente se le puede añadir su respectiva linea verde divisora y/o un margen hacia abajo
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="title">El texto principal que será insertado en el título</param>
        /// <param name="smallText">El texto secundario y más pequeño que será insertado a la derecha de el título</param>
        /// <param name="includeGreenStripe">True si desea añadir la linea verde divisora</param>
        /// <param name="includeBottomMargin">True si desea añadir un margen hacia abajo</param>
        /// <returns></returns>
        public static MvcHtmlString PageTitle(this HtmlHelper helper, string title, string smallText, bool includeGreenStripe, bool includeBottomMargin)
        {
            TagBuilder container = new TagBuilder("div");
            container.MergeAttribute("id", "page-title-container");

            // Create page-title h3, with optional small text, then add it to the container
            TagBuilder pagetitle = new TagBuilder("h3");
            pagetitle.AddCssClass("page-title");
            pagetitle.SetInnerText(title);
            if (!String.IsNullOrEmpty(smallText)) {
                TagBuilder small = new TagBuilder("small");
                small.SetInnerText(smallText);
                pagetitle.InnerHtml += " " + small.ToString();
            }
            container.InnerHtml += pagetitle.ToString();
            
            // If green stripe is included, create it and add it to container
            if (includeGreenStripe)
            {
                TagBuilder greenStripe = new TagBuilder("hr");
                greenStripe.AddCssClass("green-stripe");
                container.InnerHtml += greenStripe.ToString();
            }

            // If bottom margin is included, create it and add it to container
            if (includeBottomMargin)
            {
                TagBuilder hrBottomMargin = new TagBuilder("hr");
                hrBottomMargin.AddCssClass("not-to-top");
                container.InnerHtml += hrBottomMargin.ToString();
            }

            return MvcHtmlString.Create(container.ToString());
        }

        private static string GetPropertyValueFromLambdaExpression<TModel, TValue>(HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            string value = string.Empty;
            TModel model = html.ViewData.Model;
            if (model != null)
            {
                var expr = expression.Compile().Invoke(model);
                if (expr != null)
                {
                    value = expr.ToString();
                }
            }
            return value;
        }

        private static IDictionary<string, object> GetPropertyValidationAttributes<TModel, TValue>(HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            IDictionary<string, object> validationAttributes = html.GetUnobtrusiveValidationAttributes(ExpressionHelper.GetExpressionText(expression), metadata);
            if (htmlAttributes == null)
            {
                htmlAttributes = validationAttributes;
            }
            else
            {
                htmlAttributes = htmlAttributes.Concat(validationAttributes).ToDictionary(k => k.Key, v => v.Value);
            }
            return htmlAttributes;
        }

    }

}