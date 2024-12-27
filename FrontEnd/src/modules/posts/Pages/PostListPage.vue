<template>
    <h1>Aktualności</h1>

    <body>
        <div>
            <div v-if="loading">Loading posts</div>
            <div v-if="error" class="error">{{ error }}</div>
            <ul v-if="posts.length">
                <li v-for="post in posts" :key="post.id">
                    <h2 v-html="cleanHtml(post.content)"></h2>
                    <img v-if="post.image !== null" :src="post.image" alt="Image" class="image" />
                    <button @click="goToPostDetails(post.id)">View Details</button>
                    <button v-if="this.$isLoggedIn()" @click="deletePost">Delete Post</button>
                    <button v-if="this.$isLoggedIn()" @click="goToPostEdit(post.id)">PostEdit</button>
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
import PostService from "../PostService"
import { format } from "date-fns";

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

    mounted() {
        this.fetchPosts();
    },

    computed: {
        formattedDate(date) {
            return format(date, "MMMM do, yyyy");
        }
    },

    methods: {
        async fetchPosts(page) {
            this.loading = true;
            this.error = null;
            PostService.fetchPosts(page)
                .then((data) => {
                    this.posts = data.data;
                    this.totalPages = data.totalPages;
                })
                .catch((error) => {
                    this.error = error.message;
                })
                .finally(() => {
                    this.loading = false;
                })
        },

        changePage(page) {
            if (page >= 1 && page <= this.totalPages) {
                this.currentPage = page;
                this.fetchPosts(page);
            }
        },

        cleanHtml(html) {
            const parser = new DOMParser();
            const doc = parser.parseFromString(html, "text/html");
            return doc.body.innerHTML;
        },

        goToPostDetails(id) {
            this.$router.push(`/post/${id}`);
        },
        
        goToPostEdit(id) {
            this.$router.push(`/posteditingpage/${id}`);
        }
    },
};
</script>

<style scoped>
/* #error {
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
    display: flex;
    flex-direction: column;
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
} */

.image {
    width: 100px;
    height: 100px;
}

/* strong {
    font-weight: bold !important
} */
</style>
