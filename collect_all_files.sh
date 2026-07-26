#!/bin/bash
# Скрипт для сбора всех файлов C# проекта и конфигурации в один текстовый файл

OUTPUT_FILE="collector.txt"
PROJECT_DIR="."

# Создаем выходной файл
echo "========================================" > "$OUTPUT_FILE"
echo "СБОРКА ФАЙЛОВ ПРОЕКТА" >> "$OUTPUT_FILE"
echo "Дата: $(date '+%Y-%m-%d %H:%M:%S')" >> "$OUTPUT_FILE"
echo "Путь к проекту: $PROJECT_DIR" >> "$OUTPUT_FILE"
echo "========================================" >> "$OUTPUT_FILE"
echo "" >> "$OUTPUT_FILE"

# Счетчики
cs_count=0
config_count=0
other_count=0

# Функция для добавления файла
add_file() {
    local file="$1"
    local header="$2"
    
    echo "----------------------------------------" >> "$OUTPUT_FILE"
    echo "$header: $file" >> "$OUTPUT_FILE"
    echo "----------------------------------------" >> "$OUTPUT_FILE"
    echo "" >> "$OUTPUT_FILE"
    
    if [ -f "$file" ]; then
        cat "$file" >> "$OUTPUT_FILE" 2>/dev/null || echo "[ОШИБКА ЧТЕНИЯ ФАЙЛА]" >> "$OUTPUT_FILE"
    fi
    
    echo "" >> "$OUTPUT_FILE"
    echo "" >> "$OUTPUT_FILE"
}

# Собираем C# файлы
echo "# C# ФАЙЛЫ" >> "$OUTPUT_FILE"
echo "" >> "$OUTPUT_FILE"

for file in $(find "$PROJECT_DIR" -name "*.cs" -type f | grep -v "bin/" | grep -v "obj/" | grep -v ".g.cs" | sort); do
    add_file "$file" "CS_FILE"
    ((cs_count++))
done

# Собираем файлы конфигурации
echo "" >> "$OUTPUT_FILE"
echo "# ФАЙЛЫ КОНФИГУРАЦИИ" >> "$OUTPUT_FILE"
echo "" >> "$OUTPUT_FILE"

for file in $(find "$PROJECT_DIR" -type f \( -name "appsettings*.json" -o -name "*.csproj" -o -name "*.sln" -o -name "*.slnx" -o -name "*.config" -o -name "*.json" \) | grep -v "bin/" | grep -v "obj/" | sort); do
    add_file "$file" "CONFIG_FILE"
    ((config_count++))
done

# Собираем другие текстовые файлы
echo "" >> "$OUTPUT_FILE"
echo "# ДРУГИЕ ФАЙЛЫ" >> "$OUTPUT_FILE"
echo "" >> "$OUTPUT_FILE"

for file in $(find "$PROJECT_DIR" -type f \( -name "*.md" -o -name "*.txt" -o -name "*.xml" -o -name "*.yml" -o -name "*.yaml" -o -name "*.sql" \) | grep -v "bin/" | grep -v "obj/" | sort); do
    add_file "$file" "OTHER_FILE"
    ((other_count++))
done

# Добавляем尾ал
echo "========================================" >> "$OUTPUT_FILE"
echo "КОНЕЦ СБОРКИ" >> "$OUTPUT_FILE"
echo "Количество файлов:" >> "$OUTPUT_FILE"
echo "  - C# файлов: $cs_count" >> "$OUTPUT_FILE"
echo "  - Конфигурационных файлов: $config_count" >> "$OUTPUT_FILE"
echo "  - Других файлов: $other_count" >> "$OUTPUT_FILE"
echo "Всего файлов: $((cs_count + config_count + other_count))" >> "$OUTPUT_FILE"
echo "========================================" >> "$OUTPUT_FILE"

echo ""
echo "Сборка завершена!"
echo "Файл создан: $OUTPUT_FILE"
echo ""
echo "Статистика:"
echo "  - C# файлов: $cs_count"
echo "  - Конфигурационных файлов: $config_count"
echo "  - Других файлов: $other_count"
echo "  - Всего файлов: $((cs_count + config_count + other_count))"
echo ""
