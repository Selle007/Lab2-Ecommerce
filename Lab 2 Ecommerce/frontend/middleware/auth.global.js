import jwt_decode from 'jwt-decode';
import Cookies from 'js-cookie';

export default defineNuxtRouteMiddleware((to, from) => {
  const token = Cookies.get('token');

  if (token) {
    const decoded = jwt_decode(token);
    const role = decoded.jti;
    let isAdmin = false;

    if (role === 'Admin') {
      isAdmin = true;
    }
    if (to.path === "/dashboard" && !isAdmin) {
      return redirect("/");
    }
  }
})


