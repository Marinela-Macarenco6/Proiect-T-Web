using System.Web;
using System.Web.Optimization;

public class BundleConfig
{
    public static void RegisterBundles(BundleCollection bundles)
    {
        bundles.Add(new StyleBundle("~/Content/assets/css").Include(
    "~/Content/assets/css/animate.min.css",
    "~/Content/assets/css/animated-headline.css",
    "~/Content/assets/css/bootstrap.min.css",
    "~/Content/assets/css/flaticon.css",
    "~/Content/assets/css/fontawesome-all.min.css",
    "~/Content/assets/css/gijgo.css",
    "~/Content/assets/css/hamburgers.min.css",
    "~/Content/assets/css/magnific-popup.css",
    "~/Content/assets/css/main.css",
    "~/Content/assets/css/nice-select.css",
    "~/Content/assets/css/owl.carousel.min.css",
    "~/Content/assets/css/price_rangs.css",
    "~/Content/assets/css/progressbar_barfiller.css",
    "~/Content/assets/css/responsive.css",
    "~/Content/assets/css/slick.css",
    "~/Content/assets/css/slicknav.css",
    "~/Content/assets/css/style.css",
    "~/Content/assets/css/themify-icons.css"
));
        bundles.Add(new StyleBundle("~/Content/assets/scss").Include(
    "~/Content/assets/scss/_about.css",
    "~/Content/assets/scss/_blog_page.css",
    "~/Content/assets/scss/_bradcam.css",
    "~/Content/assets/scss/_collaps.css",
    "~/Content/assets/scss/_color.css",
    "~/Content/assets/scss/_common.css",
    "~/Content/assets/scss/_contact.css",
    "~/Content/assets/scss/_contact_form.css",
    "~/Content/assets/scss/_courses.css",
    "~/Content/assets/scss/_elements.css",
    "~/Content/assets/scss/_extend.css",
    "~/Content/assets/scss/_footer.css",
    "~/Content/assets/scss/_h1-hero.css",
    "~/Content/assets/scss/_header.css",
    "~/Content/assets/scss/_load-balnceing.css",
    "~/Content/assets/scss/_login.css",
    "~/Content/assets/scss/_mixins.css",
    "~/Content/assets/scss/_overlay.css",
    "~/Content/assets/scss/_services.css",
    "~/Content/assets/scss/_services_section.css",
    "~/Content/assets/scss/_team.css",
    "~/Content/assets/scss/_testimonial.css",
    "~/Content/assets/scss/_top-sub.css",
    "~/Content/assets/scss/_variables.css",
    "~/Content/assets/scss/_wantTowork.css",
    "~/Content/assets/scss/style.css"
));



        // Bundle pentru JavaScript 
        bundles.Add(new ScriptBundle("~/Scripts/js").Include(
            "~/Scripts/vendor/modernizr-3.5.0.min.js",
            "~/Scripts/vendor/jquery-1.12.4.min.js",
            "~/Scripts/popper.min.js",
            "~/Scripts/bootstrap.min.js",
            "~/Scripts/jquery.slicknav.min.js",
            "~/Scripts/owl.carousel.min.js",
            "~/Scripts/slick.min.js",
            "~/Scripts/wow.min.js",
            "~/Scripts/animated.headline.js",
            "~/Scripts/jquery.magnific-popup.js",
            "~/Scripts/gijgo.min.js",
            "~/Scripts/jquery.nice-select.min.js",
            "~/Scripts/jquery.sticky.js",
            "~/Scripts/jquery.barfiller.js",
            "~/Scripts/jquery.counterup.min.js",
            "~/Scripts/waypoints.min.js",
            "~/Scripts/jquery.countdown.min.js",
            "~/Scripts/hover-direction-snake.min.js",
            "~/Scripts/contact.js",
            "~/Scripts/jquery.form.js",
            "~/Scripts/jquery.validate.min.js",
            "~/Scripts/mail-script.js",
            "~/Scripts/jquery.ajaxchimp.min.js",
            "~/Scripts/plugins.js",
            "~/Scripts/main.js"));



        BundleTable.EnableOptimizations = false; // Dezactivează minificarea
    }
    }

