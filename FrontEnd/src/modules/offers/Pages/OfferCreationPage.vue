<template>

    <body>
        <div id="middle-block">
            <div class="post-container">
                <h2>Stwórz Nową Ofertę</h2>
                <div>
                    <label for="title">Title:</label>
                    <textarea v-model="offer.title"></textarea>
                </div>
                <div>
                    <vue-editor v-model="offer.content"></vue-editor>
                </div>
            </div>

            <div>
                <button class="post-button" @click="saveOffer">Stwórz</button>
                <button @click="$router.push({ name: 'offer' })">Powrót</button>
            </div>
        </div>
    </body>
</template>

<script>
import OfferService from "../OfferService.js"
import { VueEditor } from "vue3-editor";

export default {
    data() {
        return {
            offer: {
                title: "",
                content: ""
            }
        }
    },

    components: {
        VueEditor
    },

    methods: {
        saveOffer() {
            OfferService.createOffer(this.offer)
                .then((offer) => {
                    alert("post is added")
                })
                .catch((error) => {
                    alert(`error, potst not added ${error}`)
                })
        },

        logout() {
            try {
                localStorage.removeItem('user');
                console.log('User has been logged out.');
            } catch (error) {
                console.error('Error during logout:', error);
            }
        }
    }
}

</script>
