<template>

    <body>
        <ul v-if="offers.length">
            <li v-for="offer in offers" :key="offer.id">
                <h1 v-html="(offer.title)"></h1>
                <h2 v-html="(offer.content)"></h2>
                <!-- <p>{{ formattedDate(post.date) }}</p> -->
                <img v-if="post.image !== null" :src="post.image" alt="Image" class="image" />
                <button @click="goToPost(post.id)">View Details</button>
            </li>
        </ul>
        <div>
            <button @click="saveOffer">Create Offer</button>
        </div>
    </body>
</template>

<script>

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
            try {
                let link = `https://localhost:7119/offers`
                const response = await fetch(link);
                if (!response.ok) {
                    throw new Error(`Error: ${response.statusText}`);
                }
                const data = await response.json();
                this.posts = data.data;
                this.totalPages = data.totalPages;
            } catch (err) {
                this.error = err.message;
            }
        },

        async deleteOffer() {
            const confirmation = confirm("Are you sure you want to delete this offer?");
            if (confirmation) {
                try {
                    const response = await fetch(`https://localhost:7119/offer/${this.id}`, {
                        method: "DELETE",
                    });
                    if (!response.ok) {
                        throw new Error(`Error: ${response.statusText}`);
                    }
                    alert("offer deleted successfully.");
                    this.$router.push("/post-list");
                } catch (err) {
                    alert(`Failed to delete offer: ${err.message}`);
                }
            }

        },

        saveOffer() {
            PostService.createOffer(this.offer)
                .then((offer) => {
                    alert("offer is added")
                })
                .catch((error) => {
                    alert(`error, offer not added ${error}`)
                })
        },

    }
}

</script>

<style scoped>
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
</style>
