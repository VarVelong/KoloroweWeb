<template>
    <div>
        <h1>Contact Us</h1>
        <form @submit.prevent="sendEmail">
            <div>
                <label for="subject">Subject:</label>
                <input v-model="subject" id="subject" required />
            </div>
            <div>
                <label for="message">Message:</label>
                <textarea v-model="message" id="message" required></textarea>
            </div>
            <button type="submit">Send</button>
        </form>
        <p v-if="responseMessage">{{ responseMessage }}</p>
    </div>

    <div>
        <h2>Kontakt</h2>
        <p  href="tel:123456789">Telefon: 123 456 789</p>
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
body {
    background-color: #4CAF50;
    margin: 0 auto;
    padding: 0;
    color: #333;
    width: 80%;
    box-sizing: border-box;
}

div {
    background-color: #FFF9C4;
    border: 3px solid #FFD54F;
    border-radius: 15px;
    padding: 20px;
    margin: 30px auto;
    max-width: 600px;
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