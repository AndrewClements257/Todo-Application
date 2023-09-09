import axios from 'axios';

export default {

  login(user) {
    return axios.post('/login', user)
  },

  register(user) {
    return axios.post('/register', user)
  },
  getInfo(id) {
    return axios.get(`/info/${id}`)
  },
  updateInfo(info) {
    return axios.put(`/info`,info)
  }
}
