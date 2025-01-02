<template>

    <body>
        <div id="middle-block">
            <div class="post-container">
                <h2>Edit Post</h2>
                <div>
                    <vue-editor v-model="post.content"></vue-editor>
                </div>
                <button class="post-button" @click="savePost">Post</button>
            </div>
        </div>
    </body>
</template>

<script>
import PostService from "../PostService"
import { VueEditor } from "vue3-editor";

export default {
    props: ["id"],
    data() {
        return {
            post: {
                content: ""
            },
            loading: false,
            error: null
        }
    },

    mounted() {
        this.fetchPost()
    },

    components: {
        VueEditor
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

        async savePost() {
            this.loading = true;
            this.error = null;
            PostService.updatePost(this.id, this.post.content)
                .then((data) => {
                    this.post = data;
                    alert("Post został pomyślnie zapisany!")
                    this.$router.push('/post-list')
                })
                .catch((error) => {
                    this.error = error.message;
                })
                .finally(() => {
                    this.loading = false;
                })
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
}

h2 {
    color: #FF6F61;
    font-size: 2em;
    margin-bottom: 10px;
    text-shadow: 1px 1px #FFD9E8;
}

.post-container {
    background: #2e2b2b;
    padding: 20px;
    max-width: 500px;
    width: 100%;
    border-radius: 8px;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
}

.post-container h2 {
    margin-bottom: 20px;
    color: #ffffff;
}

.post-button {
    display: block;
    width: 100%;
    padding: 10px;
    background-color: #007bff;
    color: white;
    border: none;
    border-radius: 5px;
    cursor: pointer;
    font-size: 16px;
    margin-top: 20px;
}
</style>
