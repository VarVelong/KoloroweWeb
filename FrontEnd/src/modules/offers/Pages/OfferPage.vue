<template>
    <h1 class="page-title">Zobacz naszą ofertę!</h1>
    <div id="offer-container">
        <ul v-if="offers.length">
            <li v-for="offer in offers" :key="offers.id">
                <h2>{{ offer.title }}</h2>
                <p v-html="cleanHtml(offer.content)" class="post-text"></p>
                <button class="btn btn-danger fas fa-trash-alt" v-if="$isLoggedIn()"
                    @click="deleteOffer(offer.id)"></button>
            </li>
        </ul>
    </div>
</template>

<script>
import OfferService from "../OfferService.js"

export default {
    props: ["id"],
    data() {
        return {
            offers: []
        };
    },

    mounted() {
        this.fetchOffers();
    },

    methods: {
        async fetchOffers() {
            this.loading = true;
            this.error = null;
            OfferService.fetchOffers()
                .then((data) => {
                    this.offers = data;
                })
                .catch((error) => {
                    this.error = error.message;
                })
                .finally(() => {
                    this.loading = false;
                })
        },

        async deleteOffer(id) {
            const confirmation = confirm("Are you sure you want to delete this offer?");
            if (confirmation) {
                OfferService.deleteOffer(id)
                    .then((data) => {
                        alert("Offer deleted successfully.");
                    })
                    .catch((error) => {
                        alert(`Failed to delete offer: ${error.message}`);
                    })
            }
        },

        cleanHtml(html) {
            const parser = new DOMParser();
            const doc = parser.parseFromString(html, "text/html");
            return doc.body.innerHTML;
        }
    }
}

</script>

<style scoped>

#offer-container{
    background-color: rgba(0, 0, 0, 0.5);
    width: 80%;
    border: 3px solid black;
    border-radius: 15px;
    padding: 20px;
    margin: 30px auto;
    box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
    text-align: center;
    min-height: 100%;
    align-items: center;
    justify-content: center;
    display: flex;
}

ul {
    list-style-type: none;
    padding: 0;
    width: 80%;
}

li {
    border: 3px solid #000000;
    border-radius: 20px;
    background-color: #ddd;
    padding: 15px;
    margin: 10px 0;
    border-radius: 5px;
}

</style>