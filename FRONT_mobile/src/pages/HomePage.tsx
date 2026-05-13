import { Link } from "react-router-dom";
import { devices, promotions, tariffs } from "../data/mockData";
import { SectionTitle } from "../components/SectionTitle";

export function HomePage() {
  return (
    <div className="page-stack">
      <section className="hero">
        <div className="hero__backdrop" />
        <div className="hero__content">
          <p className="hero__eyebrow">( devices / tariffs / repair service )</p>
          <h1>
            SALON
            <br />
            SVYAZI
          </h1>
          <p className="hero__lead">
            Витрина для устройств, тарифов и сервисных сценариев с отдельными пространствами
            для клиента, сотрудника и администратора.
          </p>
          <div className="hero__actions">
            <Link className="primary-button" to="/client">
              Кабинет клиента
            </Link>
            <Link className="ghost-button ghost-button--light" to="/staff">
              Панель сотрудника
            </Link>
          </div>
        </div>
      </section>

      <section className="ink-panel">
        <div className="two-column-intro">
          <div className="portrait-tile portrait-tile--soft" />
          <div>
            <SectionTitle
              eyebrow="О проекте"
              title="Фронт для салона связи в журнальной подаче"
              description="Вместо шаблонной витрины здесь заложен более fashion-editorial подход: спокойный фон, насыщенные тёмные плоскости, тонкая антиква и крупные композиционные блоки."
            />

            <div className="feature-columns">
              <div>
                <h3>( витрина )</h3>
                <p>
                  Гость видит устройства, тарифы и акции. Карточки адаптированы под будущую
                  фильтрацию, пагинацию и REST-интеграцию.
                </p>
              </div>
              <div>
                <h3>( кабинеты )</h3>
                <p>
                  Для клиента, сотрудника и администратора уже заложены отдельные маршруты и
                  UI-сценарии, пока без подключения к API.
                </p>
              </div>
            </div>
          </div>
        </div>
      </section>

      <section className="paper-section">
        <SectionTitle
          eyebrow="Телефоны"
          title="Устройства"
          description="Карточки построены так, чтобы потом сюда без переделки посадить реальные данные из `/devices`."
        />
        <div className="catalog-grid">
          {devices.map((device) => (
            <article key={device.id} className={`catalog-card catalog-card--${device.accent}`}>
              <div className="catalog-card__media" />
              <div className="catalog-card__body">
                <span>{device.category}</span>
                <h3>{device.model}</h3>
                <p>{device.manufacturer}</p>
                <div className="catalog-card__footer">
                  <strong>{device.retailPrice.toLocaleString("ru-RU")} ₽</strong>
                  <small>остаток {device.stock}</small>
                </div>
              </div>
            </article>
          ))}
        </div>
      </section>

      <section className="showcase-grid">
        <div className="showcase-grid__copy">
          <SectionTitle
            eyebrow="Тарифы"
            title="Планы связи"
            description="Блок собран как самостоятельная editorial-полоса: светлый фон, чёткая типографика, метрики в коротком формате."
          />
        </div>

        {tariffs.map((tariff) => (
          <article key={tariff.id} className="metric-card">
            <span>{tariff.operator}</span>
            <h3>{tariff.name}</h3>
            <p>{tariff.monthlyPrice} ₽ / месяц</p>
            <ul>
              <li>{tariff.minutes} минут</li>
              <li>{tariff.internetGb} ГБ</li>
              <li>{tariff.sms} SMS</li>
            </ul>
          </article>
        ))}
      </section>

      <section className="ink-panel ink-panel--quote">
        <p>
          Мы не просто продаём устройства и тарифы. Мы собираем целую поверхность взаимодействия,
          где каталог, сервис и личные кабинеты выглядят как единая вещь, а не как набор
          случайных экранов.
        </p>
      </section>

      <section className="paper-section">
        <SectionTitle
          eyebrow="Акции"
          title="Промо-блок"
          description="Эти блоки позже будут наполняться данными из `/promotions`, а сейчас показывают композицию и иерархию."
        />

        <div className="promo-grid">
          {promotions.map((promotion, index) => (
            <article key={promotion.id} className={index === 1 ? "promo-card promo-card--wide" : "promo-card"}>
              <div className="promo-card__media" />
              <div className="promo-card__body">
                <span>{promotion.period}</span>
                <h3>{promotion.title}</h3>
                <p>{promotion.description}</p>
              </div>
            </article>
          ))}
        </div>
      </section>
    </div>
  );
}
