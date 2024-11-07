import MainPage from "../components/MainPage.vue"
import AboutPage from "../components/AboutPage.vue"
import ContactPage from "../components/ContactPage.vue"
import OfferPage from "../components/OfferPage.vue"
import PersonnelPage from "../components/PersonnelPage.vue"
import UpdatePage from "../components/UpdatePage.vue"
import PostCreationPage from "../components/PostCreationPage.vue"
import AuthorizationPage from "../components/AuthorizationPage.vue"

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
            path: '/authorization',
            name: 'authorization',
            component: AuthorizationPage
        },

        {
            path: '/postcreation',
            name: 'postcreation',
            component: PostCreationPage
        }
    ]