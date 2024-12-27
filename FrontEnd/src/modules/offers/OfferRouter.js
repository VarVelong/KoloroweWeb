import OfferPage from "./Pages/OfferPage.vue";
import OfferCreationPage from "./Pages/OfferCreationPage.vue"

export default
[
    {
        path: '/offer',
        name: 'offer',
        component: OfferPage
    },

    {
        path: '/offercreationpage',
        name: 'offercreationpage',
        component: OfferCreationPage
    }
]