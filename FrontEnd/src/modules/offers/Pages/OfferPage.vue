<template>

    <body>
        <ul v-if="offers.length">
            <li v-for="offer in offers" :key="offers.id">
                <h2>{{offer.id}}</h2>
                <button v-if="this.$isLoggedIn()" @click="deleteOffer(offer.id)">Usuń Ofertę</button>
            </li>
        </ul>
    </body>
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
            const confirmation = confirm("Are you sure you want to delete this post?");
            if (confirmation) {
                OfferService.deleteOffer(id)
                .then((data) => {
                    alert("Post deleted successfully.");
                })
                .catch((error) => {
                    alert(`Failed to delete post: ${error.message}`);
                })
            }
        }
    }
}

</script>

<!-- <style scoped>
body {
    background-color: #4CAF50;
    margin: 0 auto;
    padding: 0;
    color: #333;
    width: 80%;
    box-sizing: border-box;
}

div {
    background-color: #FFF9C4;
    border: 3px solid #FFD54F;
    border-radius: 15px;
    padding: 20px;
    margin: 0 auto;
    max-width: 600px;
    box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
    text-align: center;
}

ul {
    list-style-type: none;
    padding: 0;
}

li {
    border: 1px solid #000000;
    padding: 15px;
    margin: 10px 0;
    border-radius: 5px;
}

h2 {
    color: #FF6F61;
    font-size: 2em;
    margin-bottom: 10px;
    text-shadow: 1px 1px #FFD9E8;
}

h3 {
    color: #FF6F61;
    font-size: 2em;
    margin-bottom: 10px;
    text-shadow: 1px 1px #FFD9E8;
}

p {
    font-size: 1.2em;
    line-height: 1.5;
    margin: 5px 0;
    color: #555;
}
</style> -->
