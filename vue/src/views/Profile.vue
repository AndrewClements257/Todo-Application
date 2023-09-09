<template>
    <div class="user-profile">
        <img src="https://fastly.picsum.photos/id/1011/60/60.jpg?hmac=4II0YyADT2KJxllHkW78APiqvJhLFYqmxdcYgE0_VcQ" class="avatar" />
        <div class="profile-info">
        <h1 class="info">Full Name</h1>
        <h1>{{ firstName }} {{ lastName }}</h1>
        <hr>
        <h1 class="info">Date of Birth</h1>
        <h1>August 13, 1995</h1>
        <br>
        <h1 class="info">Home Country</h1>
        <h1>United States</h1>
        </div>
    </div>
</template>

<script>
import AuthService from '../services/AuthService';

export default {
    name: 'profile',
    created () {
      this.getInfo(this.$store.state.user.userId);
    },
    data() {
      return {
        userInfo: {}
      }
    },
    computed: {
      firstName() {
            return this.$store.state.user_info.firstName;
        },
        lastName() {
            return this.$store.state.user_info.lastName;
        }
    },
    methods: {
      getInfo(id) {
        try {
          AuthService.getInfo(id).then(response => {
            if(response.response === 200) {
              this.userInfo = response.data;
          }
        });
        } catch {
          console.error("Error fetching user info")
        }},
        updateInfo(id) {
        try {
          AuthService.updateInfo(id).then(response => {
            if(response.response === 200) {
              this.userInfo = response.data;
          }
        });
        } catch {
          console.error("Error updating user info")
        }}
    }
}
</script>

<style>
.user-profile {
  display: flex;
  background-color: white;
  flex-direction: column;
  /* justify-content: center; */
  align-items: center;
  padding-top: 60px;
  width: 100%;
  height: 100vh;
}

.user-profile>img {
  margin-bottom: 40px;
}

.profile-info {
  padding: 40px 20px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  background-color: dodgerblue;
  width: 50%;
  text-align: center;
  color: white;
  text-shadow: 2px 2px 2px rgba(0,0,0,0.14);
  /* background: rgba(255, 255, 255, 0.1); */
  border-radius: 10px; 
  backdrop-filter: blur(3px); 
  border: 1px solid rgba(255, 255, 255, 0.2);
}

.info {
  float: left;
}

.avatar {
    border-radius: 100px;
        width: 200px;
        padding-right: 5px;
}

hr {
  border: none;
  height: 1px;
}
</style>