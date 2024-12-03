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
        </div>
    </div>
</template>

<script>
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
            try {
                const response = await fetch(`https://localhost:7119/userpost/${this.id}`);
                if (!response.ok) {
                    throw new Error(`Error: ${response.statusText}`);
                }
                const data = await response.json();
                this.post = data;
            } catch (err) {
                this.error = err.message;
            } finally {
                this.loading = false;
            }
        },

        async deletePost() {
            const confirmation = confirm("Are you sure you want to delete this post?");
            if (confirmation) {
                try {
                    const response = await fetch(`https://localhost:7119/userpost/${this.id}`, {
                        method: "DELETE",
                    });
                    if (!response.ok) {
                        throw new Error(`Error: ${response.statusText}`);
                    }
                    alert("Post deleted successfully.");
                    this.$router.push("/post-list");
                } catch (err) {
                    alert(`Failed to delete post: ${err.message}`);
                }
            }

        },

        created() {
            this.fetchPost();
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