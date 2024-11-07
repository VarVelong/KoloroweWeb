<template>
    <body>
    
            <form>
                <h2>Zaloguj się żeby kontynuować</h2>
                <input type="text" placeholder="Login" required>
                <input type="password" placeholder="Hasło" required>
                <button type="submit">Wyślij</button>
            </form>

    </body>
</template>
    
<style scoped>
body {
    font-family: Arial, sans-serif;
    margin: 0;
    padding: 0;
}

form {
    display: flex;
    flex-direction: column;
    margin: 10px;
    gap: 10px;
}
</style>