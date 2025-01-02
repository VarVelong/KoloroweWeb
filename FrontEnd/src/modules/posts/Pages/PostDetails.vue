<template>
    <div id="middle-block">
        <div id="post-details">
            <h1>Post Details</h1>
            <div v-if="loading">Loading post...</div>
            <div v-if="error" class="error">{{ error }}</div>
            <div v-if="post">
                <h1>{{ post.title }}</h1>
                <h2>{{ plainPostText }}</h2>
                <p>{{ formattedDate }}</p>
                <img v-if="post.image !== null" :src="post.image" alt="Image" class="image" />
                <button @click="$router.push('/post-list')">Back to Posts</button>
                <button @click="deletePost">Delete Post</button>
                <button @click="goToPost(post.id)">PostEdit</button>
            </div>
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
#middle-block {
  position: absolute;
  top: 0;
  bottom: 0;
  left: 50%;
  transform: translateX(-50%);
  width: 700px;
  background-color: rgba(0, 0, 0, 0.5);
  border: none;
  margin-top: 125px;
  border-radius: 0px;
}

.image {
    width: 100px;
    height: 100px;
}

div {
    background-color: #FFF9C4;
    border: 3px solid #FFD54F;
    border-radius: 15px;
    padding: 20px;
    margin: 30px auto;
    box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
    text-align: center;
}

h2 {
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
