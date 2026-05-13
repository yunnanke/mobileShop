import { Link, NavLink } from "react-router-dom";
import { useMemo, useState, type ReactNode } from "react";
import { useAuth } from "../app/AuthContext";
import { LoginModal } from "./LoginModal";
import type { DemoRole } from "../types/auth";

function roleName(role: DemoRole): string {
  switch (role) {
    case "client":
      return "Клиент";
    case "consultant":
      return "Сотрудник";
    case "admin":
      return "Администратор";
    default:
      return "Гость";
  }
}

export function AppShell({ children }: { children: ReactNode }) {
  const [isLoginOpen, setLoginOpen] = useState(false);
  const { session, signOut, setRole } = useAuth();

  const roleLinks = useMemo(() => {
    const links = [{ to: "/", label: "Витрина" }];

    if (session.role === "client" || session.role === "admin") {
      links.push({ to: "/client", label: "Кабинет" });
    }

    if (session.role === "consultant" || session.role === "admin") {
      links.push({ to: "/staff", label: "Сотрудник" });
    }

    if (session.role === "admin") {
      links.push({ to: "/admin", label: "Админ" });
    }

    return links;
  }, [session.role]);

  return (
    <div className="app-frame">
      <header className="topbar">
        <div className="topbar__meta">
          <span>FRONT MOBILE</span>
          <span>mock mode</span>
        </div>

        <div className="topbar__brand">
          <Link to="/">SALON SVYAZI</Link>
        </div>

        <div className="topbar__actions">
          <div className="role-pills">
            {(["guest", "client", "consultant", "admin"] as DemoRole[]).map((role) => (
              <button
                key={role}
                type="button"
                className={role === session.role ? "role-pill role-pill--active" : "role-pill"}
                onClick={() => setRole(role)}
              >
                {roleName(role)}
              </button>
            ))}
          </div>

          {session.isAuthenticated ? (
            <button type="button" className="ghost-button" onClick={signOut}>
              Выйти
            </button>
          ) : (
            <button type="button" className="ghost-button" onClick={() => setLoginOpen(true)}>
              Войти
            </button>
          )}
        </div>
      </header>

      <nav className="site-nav">
        {roleLinks.map((link) => (
          <NavLink
            key={link.to}
            to={link.to}
            className={({ isActive }) => (isActive ? "site-nav__link active" : "site-nav__link")}
          >
            {link.label}
          </NavLink>
        ))}
      </nav>

      <main>{children}</main>

      <footer className="footer-block">
        <p>Frontend-концепт по ТЗ. Бэкенд пока не подключён.</p>
        <p>Будущая интеграция: REST + role-based navigation + forms.</p>
      </footer>

      <LoginModal isOpen={isLoginOpen} onClose={() => setLoginOpen(false)} />
    </div>
  );
}
