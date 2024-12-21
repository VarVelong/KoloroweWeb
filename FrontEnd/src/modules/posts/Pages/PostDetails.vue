<template>
    <div id="post-details">
        <h1>Post Details</h1>
        <div v-if="loading">Loading post...</div>
        <div v-if="error" class="error">{{ error }}</div>
        <div v-if="post">
            <h2>{{ plainPostText }}</h2>
            <p>{{ formattedDate }}</p>
            <img v-if="post.image !== null" :src="post.image" alt="Image" class="image" />
            <button @click="$router.push('/post-list')">Back to Posts</button>
            <button @click="deletePost">Delete Post</button>
            <button @click="goToPost(post.id)">PostEdit</button>
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
    width: 100px;
    height: 100px;
}
</style>