import React, { useEffect, useState } from "react";
import axios from "axios";

interface Tarefa {
    id: number;
    descricao: string;
    concluida: boolean;
    categoriaId: number;
    categoria: { id: number; nome: string };
}

const Tarefas: React.FC = () => {
    const [tarefas, setTarefas] = useState<Tarefa[]>([]);

    useEffect(() => {
        axios.get("http://localhost:5273/api/tarefas/listar")
            .then(response => setTarefas(response.data))
            .catch(error => console.error(error));
    }, []);

    return (
        <div>
            <h1>Tarefas</h1>
            <ul>
                {tarefas.map(t => (
                    <li key={t.id}>
                        {t.descricao} - {t.concluida ? "Concluída" : "Não Concluída"} ({t.categoria.nome})
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default Tarefas;
