<template>
    <div id="post-details">
        <h1>Post Details</h1>
        <div v-if="loading">Loading post...</div>
        <div v-if="error" class="error">{{ error }}</div>
        <div v-if="post">
            <h2>{{ post.content }}</h2>
            <p>{{ post.date }}</p>
            <button @click="$router.push('/updates')">Back to Posts</button>
            <button @click="deletePost">Delete Post</button>
        </div>
    </div>
</template>

<script>
export default {
    props: ["id"],
    data() {
        return {
            post: null,
            loading: false,
            error: null,
        };
    },

    mounted() {
        this.fetchPost()
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
                    this.$router.push("/updates");
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