<template>
    <div id="modal-container">
        <div class="form-container">
            <button @click="close">x</button>
            <form class="edit-user-info" @submit.prevent="updateInfo(userInfo)">
                <ul>
                    <li class="title">Edit User Info</li>
                    <li>
                        <input type="text" placeholder="First Name" v-model="userInfo.firstName">
                    </li>
                    <li>
                        <input type="text" placeholder="Last Name" v-model="userInfo.lastName">
                    </li>
                    <li>
                        <input type="date" placeholder="Birthday" v-model="userInfo.birthday">
                    </li>
                    <li>
                        <input type="text" placeholder="Home Country" v-model="userInfo.homeCountry">
                    </li>
                </ul>
                <button class="submit-user-info">Submit</button>
            </form>
        </div>
    </div>
</template>

<script>
import AuthService from '../services/AuthService';

export default {
    name: "EditInfoModal",
    created () {
      this.getInfo(this.$store.state.user.userId);
    },
    data() {
        return {
            userInfo: {
                firstName: "",
                lastName: "",
                birthday: "",
                homeCountry: "",
                userId: ""
            }
        }
    },
    methods: {
    close() {
      this.$emit("close");
    },
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
              this.close();    
          }
        });
        } catch {
          console.error("Error updating user info")
        }},
  },
}
</script>

<style>
#modal-container {
    position: fixed;
    top: 0;
    bottom: 0;
    left: 0;
    right: 0;
    text-align: center;
    color: white;
    background: rgba(255, 255, 255, 0.1); 
    border-radius: 10px; 
    backdrop-filter: blur(3px); 
    width: 100%;
    padding: 20px;
    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
    display: flex;
    justify-content: center;
    align-items: center;
    }

.title {
    font-weight: 500;
    font-size: 35px;
    color: #616161;
}

li {
    padding: 5px;
}

li > input {
    height: 2vw;
}

.form-container {
    position: relative;
    background-color: white;
    width: 30%;
    height: 50%;
    border-radius: 10px;
    display: flex;
    padding-top: 50px;
    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.2);
}


.form-container>button:nth-child(1) {
    position: absolute;
    top: 0;
    right: 0;
    padding-right: 18px;
    font-size: 25px;
    color: #616161;
    align-content: center;
    border-radius: 50px;
    border: none;
    background-color: white;
    cursor: pointer;
}

.form-container>button:nth-child(1):hover {
    color: red;
} 

.submit-user-info {
    padding: 12px 16px;
    border: none;
    border-radius: 4px;
    background-color: #4368E3;
    color: white;
    font-weight: normal;
    font-size: 15px;
    cursor: pointer;
    float: center;
    width: 32%;
    margin-top: 25px;
}

.submit-user-info:hover {
    background-image: linear-gradient(to bottom right, #7f0cf2, dodgerblue);
}

.edit-user-info {
    width: 100%;
}

li>input {
    width: 55%;
}

</style>