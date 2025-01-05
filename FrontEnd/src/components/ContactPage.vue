<template>
    <div class="container">
        <h1 class="page-title">Skontaktuj się z nami!</h1>
        <form @submit.prevent="sendEmail">
            <div class="label-div">
                <label for="subject">Temat:</label>
                <input v-model="subject" id="subject" required />
            </div>
            <div class="label-div">
                <label for="message">Wiadomość:</label>
                <textarea v-model="message" id="message" required></textarea>
            </div>
            <button class="button-orange" type="submit">Wyślij</button>
        </form>
        <p v-if="responseMessage">{{ responseMessage }}</p>
    </div>

    <div class="container">
        <h2>Kontakt</h2>
        <p href="tel:123456789">Telefon: 123 456 789</p>
        <p href="mailto:biuro@kolorowe.gda.pl">Email: biuro@kolorowe.gda.pl</p>
    </div>
</template>

<script>
export default {
    data() {
        return {
            subject: "",
            message: "",
            responseMessage: "",
        };
    },
    methods: {
        async sendEmail() {
            try {
                const response = await fetch("https://localhost:7119/Communication", {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json",
                    },
                    body: JSON.stringify({
                        subject: this.subject,
                        message: this.message,
                    }),
                });

                if (!response.ok) {
                    const errorMessage = await response.text();
                    throw new Error(errorMessage || "Failed to send email.");
                }

                const responseData = await response.text();
                this.responseMessage = responseData;
            } catch (error) {
                this.responseMessage = error.message;
            }
        },
    },
};
</script>

<style scoped>
/* div {
    background-color: #FFF9C4;
    border: 3px solid #FFD54F;
    border-radius: 15px;
    padding: 20px;
    margin: 30px auto;
    box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
    text-align: center;
} */

.container{
    background-color: #ddd;
    width: 80%;
    border: 3px solid black;
    border-radius: 15px;
    padding: 20px;
    margin: 30px auto;
    box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
    text-align: center;
    min-height: 100%;
}

.label-div {
    display: flex;
    flex-direction: column;
    align-items: center;
    margin-bottom: 20px;
}

.label-div label {
    font-weight: bold;
    margin-bottom: 5px;
}

.label-div textarea {
    width: 100%;
    max-width: 400px;
    min-height: 50px;
    resize: vertical;
    border: 1px solid #ccc;
    border-radius: 4px;
    padding: 8px;
    font-size: 14px;
}
</style>