import MainPage from "../components/MainPage.vue"
import AboutPage from "../components/AboutPage.vue"
import ContactPage from "../components/ContactPage.vue"
import OfferPage from "../components/OfferPage.vue"
import PersonnelPage from "../components/PersonnelPage.vue"
import UpdatePage from "../components/UpdatePage.vue"
import PostCreationPage from "../components/PostCreationPage.vue"
import Login from "../authorization/Login.vue"
import Register from "../authorization/Register.vue"
import UpdatesPage from "../components/UpdatesPage.vue"
import PostDetails from "../components/PostDetails.vue";

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
            path: '/update',
            name: 'update',
            component: UpdatePage
        },

        {
            path: '/offer',
            name: 'offer',
            component: OfferPage
        },

        {
            path: '/personnel',
            name: 'personnel',
            component: PersonnelPage
        },
        
        {
            path: '/contact',
            name: 'contact',
            component: ContactPage
        },

        {
            path: '/postcreation',
            name: 'postcreation',
            component: PostCreationPage
        },

        {
            path: '/login',
            name: 'login',
            component: Login
        },

        {
            path: '/register',
            name: 'register',
            component: Register
        },

        {
            path: '/updates',
            name: 'updates',
            component: UpdatesPage
        },

        {
            path: '/post/:id',
            name: 'postdetails',
            component: PostDetails,
            props: true
        }
    ]