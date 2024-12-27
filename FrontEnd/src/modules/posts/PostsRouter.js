import PostCreationPage from "./Pages/PostCreationPage.vue";
import PostListPage from "./Pages/PostListPage.vue";
import PostDetails from "./Pages/PostDetails.vue";
import PostEditingPage from "./Pages/PostEditingPage.vue";

export default
[
    {
        path: '/postcreation',
        name: 'postcreation',
        component: PostCreationPage
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
    }
]