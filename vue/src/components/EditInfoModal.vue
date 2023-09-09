<template>
    <div id="modal-container">
        <form class="edit-user-info">
            <ul>
                <li class="title">Edit User Info</li>
                 <li>
                    <input type="text" placeholder="Your First Name" v-model="userInfo.firstName">
                </li>
            </ul>
            <button class="submit-user-info">Submit</button>
        </form>
    </div>
</template>

<script>
export default {
    data() {
        return {
            userInfo: {

            }
        }
    }
}
</script>

<style>
#modal-container {
    text-align: center;
    width: 100%;
    color: white;
    background: rgba(255, 255, 255, 0.1); 
  border-radius: 10px; 
  backdrop-filter: blur(3px); 
  border: 1px solid rgba(255, 255, 255, 0.2);
  max-width: 350px;
  width: 90%;
  padding: 20px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);

  margin: 25px;
}

.title {
    font-size: 25px;
    color: white;
}

li {
    padding: 5px;
}

li > input {
    height: 2vw;
}

.submit-user-info {
  padding: 12px 16px;
  border: none;
  border-radius: 4px;
  background-color: dodgerblue;
  color: black;
  font-weight: normal;
  font-size: 15px;
  cursor: pointer;
  float: center;
}

.edit-user-info {
    width: 100%;
}


</style>