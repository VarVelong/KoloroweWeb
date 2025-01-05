<template>
        <div id="post-details">
            <h1 class="page-title">Sczegóły postu</h1>
            <div v-if="loading">Wczytywanie postu...</div>
            <div v-if="error" class="error">{{ error }}</div>
            <div v-if="post" id="post-content">
                <p id="date">{{ formattedDate }}</p>
                <h1 id="title">{{ post.title }}</h1>
                <img v-if="post.image !== null" :src="post.image" alt="Image" class="image" />
                <p class="post-text">{{ plainPostText }}</p>
                <button class="button-orange" @click="$router.push('/post-list')">Back to Posts</button>
                <button class="btn btn-danger fas fa-trash-alt" @click="deletePost"></button>
                <button class="btn btn-warning fas fa-edit" @click="goToPost(post.id)"></button>
            </div>
        </div>
</template>

<script>
import PostService from "../PostService"
import { format } from "date-fns";

export default {
    props: ["id"],
    data() {
        return {
            post: null,
            loading: false,
            error: null
        };
    },


    mounted() {
        this.fetchPost()
    },

    computed: {
        plainPostText() {
            const div = document.createElement("div");
            div.innerHTML = this.post.content;
            return div.textContent || "";
        },

        formattedDate() {
            return format(this.post.date, "MMMM do, yyyy");
        }
    },

    methods: {
        async fetchPost() {
            this.loading = true;
            this.error = null;
            PostService.getPost(this.id)
                .then((data) => {
                    this.post = data;
                })
                .catch((error) => {
                    this.error = error.message;
                })
                .finally(() => {
                    this.loading = false;
                })
        },

        async deletePost() {
            const confirmation = confirm("Are you sure you want to delete this post?");
            if (confirmation) {
                PostService.deletePost(this.id)
                    .then((data) => {
                        alert("Post deleted successfully.");
                        this.$router.push("/post-list");
                    })
                    .catch((error) => {
                        alert(`Failed to delete post: ${error.message}`);
                    })
            }
        },

        created() {
            this.fetchPost();
        },

        goToPost(id) {
            this.$router.push(`/posteditingpage/${id}`);
        }
    }
}
</script>

<style scoped>
.image {
    max-width: 300px;
    max-height: 300px;
}

div {
    border-radius: 15px;
    padding: 20px;
    margin: 30px auto;
    text-align: center;
}

#post-content {
    background-color: #ddd;
    border: 3px solid black;
    border-radius: 15px;
}

#title{
    font-family: 'Arial', sans-serif;
    font-size: 3rem;
    color: #2c3e50;
    text-align: center;
    margin: 20px 0;
}

#date{
    font-family: 'Arial', sans-serif;
    font-size: 0.6rem;
    color: black;
    text-align: left;
    margin: 10px 0;
    line-height: 1.6;
}

button{
    margin: 10px;
    padding: 15px;
}

/* p {
    font-size: 1.2em;
    line-height: 1.5;
    margin: 5px 0;
    color: #555;
} */
</style>
