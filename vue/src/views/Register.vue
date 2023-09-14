<template>
  <div id="register" class="text-center">
    <h1 class="app-name">Andysoft To Do</h1>
    <form class="register-form" @submit.prevent="register">
      <h1 class="register-title" >Create Account</h1>
      <div role="alert" v-if="registrationErrors">
        {{ registrationErrorMsg }}
      </div>
      <div class="form-input-group">
        <label for="username">Username</label>
        <input class="register-input" type="text" id="username" v-model="user.username" required autofocus />
      </div>
      <div class="form-input-group">
        <label for="password">Password</label>
        <input class="register-input" type="password" id="password" v-model="user.password" required />
      </div>
      <div class="form-input-group">
        <label for="confirmPassword">Confirm Password</label>
        <input class="register-input" type="password" id="confirmPassword" v-model="user.confirmPassword" required />
      </div>
      <button class="register-button" type="submit">Create Account</button>
      <router-link :to="{ name: 'login' }">Already have an account? Log in.</router-link>
    </form>
  </div>
</template>

<script>
import authService from '../services/AuthService';

export default {
  name: 'register',
  data() {
    return {
      user: {
        username: '',
        password: '',
        confirmPassword: '',
        role: 'user',
      },
      registrationErrors: false,
      registrationErrorMsg: 'There were problems registering this user.',
    };
  },
  methods: {
    register() {
      if (this.user.password != this.user.confirmPassword) {
        this.registrationErrors = true;
        this.registrationErrorMsg = 'Password & Confirm Password do not match.';
      } else {
        authService
          .register(this.user)
          .then((response) => {
            if (response.status == 201) {
              this.$router.push({
                path: '/login',
                query: { registration: 'success' },
              });
            }
          })
          .catch((error) => {
            const response = error.response;
            this.registrationErrors = true;
            if (response.status === 400) {
              this.registrationErrorMsg = 'Bad Request: Validation Errors';
            }
          });
      }
    },
    clearErrors() {
      this.registrationErrors = false;
      this.registrationErrorMsg = 'There were problems registering this user.';
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
  margin-bottom: 32px;
}
#register {
  display: flex;
  flex-direction: column;
  align-items: center;
  width: 100%;
  height: 100%;
  background-color: #4368E3;
}

.register-form {
  padding: 32px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  max-width: 400px;
  width: 90%;
  color: white;
  text-shadow: 2px 2px 2px rgba(0,0,0,0.14);
  background: rgba(255, 255, 255, 0.1); 
  border-radius: 10px; 
  backdrop-filter: blur(3px); 
  border: 1px solid rgba(255, 255, 255, 0.2);
}

.register-title {
  font-size: 2em;
  font-weight: 100;
  text-align: center;
  margin-bottom: 32px;
}

.app-name {
  font-size: 5em;
  font-weight: 600;
  text-shadow: 2px 2px 2px rgba(0,0,0,0.14);
  text-align: center;
  margin-top: 32px;
  margin-bottom: 64px;
  color: white;
}

.register-input {
  width: 100%;
  padding: 12px 16px;
  margin-bottom: 16px;
  border: none;
  border-radius: 4px;
}

.register-button {
  width: 100%;
  padding: 12px 16px;
  border: none;
  border-radius: 4px;
  background-color: #7f0cf2;
  color: white;
  font-weight: normal;
  font-size: 15px;
}
.register-button:hover {
  background-image: linear-gradient(to bottom right, #7f0cf2, dodgerblue);
}

.register-form>a:hover {
        color: rgb(203, 194, 252);
    }

.register-form>a,a:visited {
        color: white;
    }

</style>

