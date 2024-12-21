import MainPage from "../components/MainPage.vue";
import AboutPage from "../components/AboutPage.vue";
import ContactPage from "../components/ContactPage.vue";
import OfferPage from "../components/OfferPage.vue";
import PersonnelPage from "../components/PersonnelPage.vue";
import PostCreationPage from "./posts/Pages/PostCreationPage.vue";
import Login from "./authorization/Pages/Login.vue";
import Register from "./authorization/Pages/Register.vue";
import PostListPage from "./posts/Pages/PostListPage.vue";
import PostDetails from "./posts/Pages/PostDetails.vue";
import PostEditingPage from "./posts/Pages/PostEditingPage.vue";
import OfferCreationPage from "./offers/Pages/OfferCreationPage.vue";
import AdminPage from "./authorization/Pages/AdminPage.vue";
import GalleryPage from "./imageGallery/Pages/GalleryPage.vue";

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
        path: '/post-list',
        name: 'post-list',
        component: PostListPage
    },

    {
        path: '/post/:id',
        name: 'postdetails',
        component: PostDetails,
        props: true
    },

    {
        path: '/posteditingpage/:id',
        name: 'posteditingpage',
        component: PostEditingPage,
        props: true
    },

    {
        path: '/offercreationpage',
        name: 'offercreationpage',
        component: OfferCreationPage
    },

    {
        path: '/adminpage',
        name: 'adminpage',
        component: AdminPage
    }, 

    {
        path: '/gallery',
        name: 'gallery',
        component: GalleryPage
    }
]