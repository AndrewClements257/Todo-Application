<template>
<div>
    <div class="user-profile">
      <div class="top-image">
      
      </div>
      <div class="avatar">
        <!-- <img src="https://fastly.picsum.photos/id/1011/60/60.jpg?hmac=4II0YyADT2KJxllHkW78APiqvJhLFYqmxdcYgE0_VcQ"/> -->
              <img src="../me.jpg" />
        <h1>{{ userInfo.firstName }} {{ userInfo.lastName }}</h1>
         <hr>
      </div>
      <div class="profile-info">
        <div class="info">
          <p>Date of Birth</p>
          <p>{{ formattedBirthday }}</p>
        </div>
        <br>
        <div class="info">
          <p>Home Country</p>
          <p>{{ userInfo.homeCountry }}</p>
        </div>
      </div>
      <button @click="modalVisible = !modalVisible">Edit Profile Info</button>
    </div>
    <Transition>
    <edit-info-modal v-if="modalVisible" @close="close" />
    </Transition>
    </div>
</template>

<script>
import EditInfoModal from '../components/EditInfoModal.vue';
import AuthService from '../services/AuthService';

export default {
    name: 'profile',
    components: { EditInfoModal },
    created () {
      this.getInfo(this.$store.state.user.userId);
    },
    data() {
      return {
        userInfo: {},
        modalVisible: false
      }
    },
    computed: {
      formattedBirthday() {
        if (this.userInfo.birthday) {
            const date = new Date(this.userInfo.birthday);
            return `${date.getMonth() + 1}/${date.getDate()}/${date.getFullYear()}`;
        }
        return '';
    }
    },
    methods: {
      getInfo(id) {
        try {
          AuthService.getInfo(id).then(response => {
            if(response.status === 200) {
              this.userInfo = response.data;
          }
        });
        } catch {
          console.error("Error fetching user info")
        }},
        updateInfo(userInfo) {
        try {
          AuthService.updateInfo(userInfo).then(response => {
            if(response.status === 200) {
              this.getInfo(this.$store.state.user.userID);    
          }
        });
        } catch {
          console.error("Error updating user info")
        }},
      close() {
        this.modalVisible = false;
        this.getInfo(this.userInfo.userId);
      }
    }
}
</script>

<style scoped>
.user-profile {
  display: flex;
  flex-direction: column;
  /* justify-content: center; */
  align-items: center;
  padding-top: 50px;
  width: 100%;
  height: 100vh;
  font-size: 20px;
}

.user-profile>img {
  margin-bottom: 40px;
}

.profile-info {
  width: 30%;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  margin-bottom: 75px;
}

.avatar {
  display: flex;
  align-items: center;
  flex-direction: column;
  text-align: center;
  margin-bottom: 10px;
  width: 100%;
}

.avatar>h1 {
  font-weight: 500;
  font-size: 35px;
}

.avatar>img {
    border-radius: 100px;
        width: 200px;
        padding-right: 5px;
        margin-top: -100px;
}

hr {
  border: 1px solid #b9b9b9;
  width: 30%;
}

.top-image {
  padding: 82px;
  width: 100vw;
  text-shadow: 2px 2px 2px rgba(0,0,0,0.14);
  background: rgb(133,113,242);
  background: linear-gradient(156deg, rgba(133,113,242,1) 0%, rgba(0,167,255,1) 50%, rgba(133,113,242,1) 100%);
}

.info {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
}

.info>p:nth-child(odd) {
  font-weight: 500;
}

.user-profile>button {
  width: 20%;
  border: none;
  background-color: #4368E3;
  color: white;
  padding: 15px;
  font-size: 20px;
  border-radius: 4px;
}

.user-profile>button:hover {
  background-image: linear-gradient(to bottom right, #7f0cf2, dodgerblue);
  cursor: pointer;
}

.v-enter-active,
.v-leave-active {
  transition: opacity 0.2s ease;
}

.v-enter-from,
.v-leave-to {
  opacity: 0;
}
</style>