<template>
    <h1>Aktualności</h1>

    <body>
        <div>
            <div v-if="loading">Loading posts</div>
            <div v-if="error" class="error">{{ error }}</div>
            <ul v-if="posts.length" class="post-list">
                <li v-for="post in posts" :key="post.id" class="post-item">
                    <h2 v-html="cleanHtml(post.content)" class="post-content"></h2>
                    <img v-if="post.image !== null" :src="post.image" alt="Image" class="post-image" />

                    <div class="button-group">
                        <button v-if="this.$isLoggedIn()" @click="deletePost(post.id)"><i class="fas fa-trash-alt"></i></button>
                        <button v-if="this.$isLoggedIn()" @click="goToPostEdit(post.id)"><i class="fas fa-edit"></i></button>
                        <button @click="goToPostDetails(post.id)">View Details</button>
                    </div>
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

        async deletePost(id) {
            const confirmation = confirm("Are you sure you want to delete this post?");
            if (confirmation) {
                PostService.deletePost(id)
                    .then((data) => {
                        alert("Post deleted successfully.");
                        this.$router.go();
                    })
                    .catch((error) => {
                        alert(`Failed to delete post: ${error.message}`);
                    })
            }
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
div {
    background-color: #FFF9C4;
    border: 3px solid #FFD54F;
    border-radius: 15px;
    padding: 20px;
    margin: 30px auto;
    box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
    text-align: center;
}

ul {
    list-style-type: none;
    padding: 0;
}

li {
    border: 2px dotted #000000;
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

.image {
    width: 100px;
    height: 100px;
}

.pagination {
    display: flex;
    align-items: center;
    justify-content: space-between;
    gap: 10px;
}

.pagination span {
    flex: 1;
    text-align: center;
}

.post-list {
    list-style: none;
    padding: 0;
    margin: 0;
}

.post-item {
    border: 1px solid #ddd;
    padding: 15px;
    margin-bottom: 20px;
    border-radius: 5px;
    background-color: #ffffff;
    border-radius: 8px;
}

.post-content {
    max-width: 500px;
    font-size: 1.5rem;
    margin-bottom: 10px;
    color: #000000;
}

.post-image {
    max-width: 100%;
    width: 500px;
    height: auto;
    display: block;
    margin: 10px 0;
}

.button-group {
    display: flex;
    gap: 10px;
    justify-content: flex-start;
    margin-top: 10px;
}
</style>