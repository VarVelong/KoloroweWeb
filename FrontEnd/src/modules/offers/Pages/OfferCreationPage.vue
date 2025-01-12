<template>
    <body>
        <div class="post-container">
            <h1 class="page-title">Stwórz Nową Ofertę</h1>
            <div id="title-div">
                <label for="title">Tytuł:</label>
                <textarea v-model="offer.title"></textarea>
            </div>
            <vue-editor v-model="offer.content"></vue-editor>
            <button class="button-orange" @click="saveOffer">Stwórz</button>
            <button class="button-orange" @click="$router.push({ name: 'offer' })">Powrót</button>
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
                    this.$router.push({ name: 'offer' })
                })
                .catch((error) => {
                    alert(`error, potst not added ${error}`)
                })
        }
    }
}

</script>

<style scoped>
.post-container {
    background: #ddd;
    padding: 20px;
    max-width: 500px;
    width: 100%;
    border-radius: 8px;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
}

.post-container h2 {
    margin-bottom: 20px;
    color: #ffffff;
}

button {
    width: 100%;
    margin: 10px;
}

#title-div {
    display: flex;
    flex-direction: column;
    align-items: center;
    margin-bottom: 20px;
}

#title-div label {
    font-weight: bold;
    margin-bottom: 5px;
}

#title-div textarea {
    width: 100%;
    max-width: 400px;
    min-height: 50px;
    resize: vertical;
    border: 1px solid #ccc;
    border-radius: 4px;
    padding: 8px;
    font-size: 14px;
}
</style>
