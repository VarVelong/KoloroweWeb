<template>
    <h1>Aktualności</h1>

    <body>
        <div>
            <div v-if="loading">Loading posts</div>
            <div v-if="error" class="error">{{ error }}</div>
            <ul v-if="posts.length">
                <li v-for="post in posts" :key="post.id">
                    <h2>{{ plainPostText(post.content) }}</h2>
                    <p>{{ post.date }}</p>
                    <img v-if="post.image !== null" :src="post.image" alt="Image" class="image" />
                    <button @click="goToPost(post.id)">View Details</button>
                </li>
            </ul>
        </div>

        <div v-if="totalPages > 1" class="pagination">
            <button @click="changePage(currentPage - 1)" :disabled="currentPage === 1">Previous</button>
            <span>Page {{ currentPage }} of {{ totalPages }}</span>
            <button @click="changePage(currentPage + 1)" :disabled="currentPage === totalPages">Next</button>
        </div>
    </body>
</template>

<script>
export default {
    data() {
        return {
            posts: [],
            loading: false,
            error: null,
            currentPage: 1,
            pageSize: 5,
            totalPages: 0,
        };
    },

    computed: {

    },

    methods: {
        async fetchPosts() {
            this.loading = true;
            this.error = null;
            try {
                const response = await fetch("https://localhost:7119/userpost");
                if (!response.ok) {
                    throw new Error(`Error: ${response.statusText}`);
                }
                const data = await response.json();
                this.posts = data;
            } catch (err) {
                this.error = err.message;
            } finally {
                this.loading = false;
            }
        },

        changePage(page) {
            if (page >= 1 && page <= this.totalPages) {
                this.currentPage = page;
                this.fetchPosts();
            }
        },

        plainPostText(post) {
            const div = document.createElement("div");
            div.innerHTML = post;
            return div.textContent || "";
        },

        goToPost(id) {
            this.$router.push(`/post/${id}`);
        },

    },
    created() {
        this.fetchPosts();
    },
};
</script>

<style scoped>
#error {
    color: red;
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

h1 {
    background-color: #4CAF50;
    padding: 20px;
    margin: 0px auto;
    width: 80%;
    box-sizing: border-box;
}

body {
    background-color: #4CAF50;
    margin: 0 auto;
    padding: 0;
    color: #333;
    width: 80%;
    box-sizing: border-box;
}

div {
    border-radius: 15px;
    padding: 20px;
    margin: 30px auto;
    max-width: 600px;
    box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
    text-align: center;
    background-color: #FFF9C4;
}

h2 {
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

.image {
    width: 100px;
    height: 100px;
}
</style>
