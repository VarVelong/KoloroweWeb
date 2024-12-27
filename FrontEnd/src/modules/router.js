import MainPage from "../components/MainPage.vue";
import AboutPage from "../components/AboutPage.vue";
import ContactPage from "../components/ContactPage.vue";

export default
[
    {
        path: '/',
        name: 'main',
        component: MainPage
    },

    {
        path: '/about',
        name: 'about',
        component: AboutPage
    },

    {
        path: '/contact',
        name: 'contact',
        component: ContactPage
    }
]