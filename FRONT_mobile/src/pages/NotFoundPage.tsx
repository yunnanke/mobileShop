import { Link } from "react-router-dom";

export function NotFoundPage() {
  return (
    <section className="paper-section not-found">
      <p>404</p>
      <h1>Страница не найдена</h1>
      <Link className="primary-button" to="/">
        Вернуться на витрину
      </Link>
    </section>
  );
}
