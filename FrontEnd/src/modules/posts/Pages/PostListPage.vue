<template>
    <h1 class="page-title">Aktualności</h1>

    <div>
        <div v-if="loading">Loading posts</div>
        <div v-if="error" class="error">{{ error }}</div>
        <ul v-if="posts.length" class="post-list">
            <li v-for="post in posts" :key="post.id" class="post-item">
                <h1>{{ post.title }}</h1>
                <img v-if="post.image !== null" :src="post.image" alt="Image" class="post-image" />
                <p v-html="cleanHtml(post.content)" class="post-text"></p>

                <div class="button-group">
                    <button class="btn btn-danger fas fa-trash-alt" v-if="$isLoggedIn()" @click="deletePost(post.id)" id="btn-left"></button>
                    <button class="button-orange" @click="goToPostDetails(post.id)" id="btn-middle">Czytaj dalej...</button>
                    <button class="btn btn-warning fas fa-edit" v-if="$isLoggedIn()" @click="goToPostEdit(post.id)" id="btn-right"></button>
                </div>
            </li>
        </ul>
    </div>

    <div v-if="totalPages > 1" id="pagination">
        <button class="button-orange" @click="changePage(currentPage - 1)" :disabled="currentPage === 1">Poprzednia strona.</button>
        <span>Page {{ currentPage }} of {{ totalPages }}</span>
        <button class="button-orange" @click="changePage(currentPage + 1)" :disabled="currentPage === totalPages">Następna strona.</button>
    </div>

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
                window.scrollTo({
                    top: 0,
                    behavior: 'smooth'
                })
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
    width: 80%;
    padding: 20px;
    margin: 30px auto;
    margin-top: 15px;
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

#title{
    /* display: flex;
    align-items: center;
    justify-content: space-between; */
    text-align: center;
    margin-top: 25px;
}

/* no clue how to make nucer */
#pagination {
    display: flex;
    align-items: center;
    justify-content: space-between;
    gap: 10px;
    margin-bottom: 100px;
    background-color: #ddd;
    border-radius: 15px;
}

#pagination span {
    flex: 1;
    text-align: center;
}

.post-list {
    list-style: none;
    padding: 0;
    margin: 0;
    border: 3px solid black;
    border-radius: 15px;
    background-color: rgba(0, 0, 0, 0.5);
    padding: 25px;
}

.post-item {
    border: 1px solid #ddd;
    padding: 15px;
    margin-bottom: 20px;
    border-radius: 5px;
    background-color: #ddd;
    border-radius: 8px;

}

.post-content {
    width: 125px;
    height: auto;
    font-size: 1.5rem;
    margin-bottom: 10px;
    color: #000000;
}

.post-image {
    width: 300px;
    height: auto;
    margin: 10px 0;
    align-items: center;
    justify-content: center;
    border: #000000 3px solid;
    padding: 10px;
    background-color: rgba(0, 0, 0, 0.5);
}


/* .button-group {
    display: flex;
    gap: 10px;
    justify-content: flex-start;
    margin-top: 10px;
}

.btn-left {
    text-align: left;
}

.btn-middle {
    text-align: center;
}

.btn-right {
    text-align: right;
} */

.button-group {
    display: flex;
    justify-content: space-between;
    align-items: center;
    gap: 10px;
}

#btn-left {
    margin-right: auto;
}

#btn-middle {
    margin: 0 auto;
}

#btn-right {
    margin-left: auto;
}
/* 
.button:hover {
    background-color: #0056b3;
} */
</style>