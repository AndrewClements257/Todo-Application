<template>
  <div id="login">
    <h1 class="app-name">Andysoft To Do</h1>
    <form class="login-form" @submit.prevent="login">
      <h1 class="login-title">Please Sign In</h1>
      <div role="alert" v-if="invalidCredentials">
        Invalid username and password!
      </div>
      <div role="alert" v-if="this.$route.query.registration">
        Thank you for registering, please sign in.
      </div>
      <div class="form-input-group">
        <label for="username">Username</label>
        <input
          class="login-input"
          type="text"
          id="username"
          v-model="user.username"
          required
          autofocus
        />
      </div>
      <div class="form-input-group">
        <label for="password">Password</label>
        <input
          class="login-input"
          type="password"
          id="password"
          v-model="user.password"
          required
        />
      </div>
      <button class="login-button" type="submit">Sign in</button>
      <router-link :to="{ name: 'register' }"
        >Need an account? Sign up.</router-link
      >
    </form>
  </div>
</template>

<script>
import authService from "../services/AuthService";

export default {
  name: "login",
  components: {},
  data() {
    return {
      user: {
        username: "",
        password: "",
        first_name: "",
        last_name: "",
      },
      invalidCredentials: false,
    };
  },
  methods: {
    async login() {
      authService
        .login(this.user)
        .then((response) => {
          if (response.status == 200) {
            this.$store.commit("SET_AUTH_TOKEN", response.data.token);
            this.$store.commit("SET_USER", response.data.user);
            this.$router.push("/");
          }
        })
        .catch((error) => {
          const response = error.response;

          if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    },
  },
};
</script>

<style scoped>
.form-input-group {
  margin-bottom: 1rem;
}
label {
  margin-right: 0.5rem;
  font-size: 1em;
  font-weight: normal;
  text-align: center;
}
#login {
  display: flex;
  flex-direction: column;
  align-items: center;
  background-color: #4368e3;
  width: 100%;
  height: 100%;
}

.login-form {
  padding: 32px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  max-width: 400px;
  width: 90%;
  color: white;
  text-shadow: 2px 2px 2px rgba(0, 0, 0, 0.14);
  background: rgba(255, 255, 255, 0.1);
  border-radius: 10px;
  backdrop-filter: blur(3px);
  border: 1px solid rgba(255, 255, 255, 0.2);
}

.login-title {
  font-size: 2em;
  font-weight: 100;
  text-align: center;
  margin-bottom: 32px;
}

.app-name {
  font-size: 5em;
  font-weight: 600;
  text-shadow: 2px 2px 2px rgba(0, 0, 0, 0.14);
  text-align: center;
  margin-top: 32px;
  margin-bottom: 64px;
  color: white;
}

.login-input {
  width: 100%;
  padding: 12px 16px;
  margin-bottom: 16px;
  border: none;
  border-radius: 4px;
}

.login-button {
  width: 100%;
  padding: 12px 16px;
  border: none;
  border-radius: 4px;
  background-color: #7f0cf2;
  color: white;
  font-weight: normal;
  font-size: 15px;
}
.login-button:hover {
  background-image: linear-gradient(to bottom right, #7f0cf2, dodgerblue);
}

.login-form > a:hover {
  color: rgb(203, 194, 252);
}

.login-form > a,
a:visited {
  color: white;
}

@media screen and (max-width: 525px) {

.app-name {
  font-size: 2.8em;
  margin-bottom: 32px;
}


}
</style>