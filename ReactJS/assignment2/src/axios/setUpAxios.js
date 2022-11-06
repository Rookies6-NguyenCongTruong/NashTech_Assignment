import axios from "axios";

export const setUpAxios = () => {
    axios.defaults.baseURL = process.env.REACT_APP_API_END_POINT;
}

export const setUpHeaderParameter = (param, value) => {
    axios.defaults.headers.common[param] = value;
}

export default axios;